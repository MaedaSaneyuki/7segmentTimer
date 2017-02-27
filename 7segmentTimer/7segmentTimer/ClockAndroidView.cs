using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Graphics.Drawables;
using System.Timers;


namespace _7segmentTimer
{
    class ClockAndroidView : View
    {
        private Timer timer;
        private Handler handler = new Handler();
        public DateTime periodEnd = DateTime.MinValue;
        public bool drucking;
        public int incleaseMinutes;
        
        private DateTime DateTime_Now
        {
            get { return DateTime.Now.AddMinutes(incleaseMinutes); }
        }

        public ClockAndroidView(Context context) : base(context)
        {
            this.SetBackgroundColor(Color.White);
            timer = new Timer();
            timer.Interval = 500;
            timer.AutoReset = true;
            timer.Enabled = true;

            timer.Elapsed += (s, v) =>
            {
                handler.Post(() => this.Invalidate());
                
               
            };
            drucking = false;
            incleaseMinutes = 0;

        }

        public override bool OnTouchEvent(MotionEvent e)
        {
        
            if(e.Action == MotionEventActions.Down)
            {
                drucking = true;
            }
            else if(e.Action == MotionEventActions.Up)
            {
                drucking = false;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("e.Action={0}", e.Action.ToString());
            }

            return base.OnTouchEvent(e);
        }


        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);
            using (var paint = new Paint())
            {
              //  TestDraw1(canvas, paint);
                clockcircle(canvas, paint);

                drawClockSecHand(canvas, paint);
                if(periodEnd > DateTime_Now)
                {
                    drawPeriod(canvas, paint);
                }
                drawClockHand(canvas, paint);
                drawClockHandTest(canvas, paint);

                clockcenter(canvas, paint);
            //    createmesh(canvas, paint);
            }

            if (drucking)
            {
                incleaseMinutes++;
            }

        }

        private void drawPeriod(Canvas canvas, Paint paint)
        {
            paint.AntiAlias = true;
            paint.StrokeWidth = 2;

            var center = Width / 2;
            var rShortHand = (float)(center * 0.60);
            var rLongHand = (float)(center * 0.80);
            var now = DateTime_Now;


            //長針
            var shitaPeriod = 360 -(15 - periodEnd.Minute) * 6;
            var shitaMin = 360 - ( 15 - now.Minute) * 6;
            

            paint.SetStyle(Paint.Style.Fill);
            paint.Color = Color.Pink;
            paint.Alpha = 80;
            canvas.DrawArc((float)(center*0.1), (float)(center * 0.1),
                (float)(center *2*0.95),
                (float)(center *2*0.95),
                (float)shitaPeriod,
                (float)shitaMin,
                true,
                paint);
            paint.SetStyle(Paint.Style.Stroke);
            paint.Color = Color.Red;
            canvas.DrawArc((float)(center * 0.1), (float)(center * 0.1),
                (float)(center * 2 * 0.95),
                (float)(center * 2 * 0.95),
                (float)shitaPeriod,
                (float)shitaMin,
                true,
                paint);

        }

        private void drawClockHandTest(Canvas canvas, Paint paint)
        {

            paint.SetStyle(Paint.Style.Fill);//スタイルを線描画に設定
            paint.Color = new Color(0x49, 0x71, 0xFF);
            paint.StrokeWidth = 5;

            var center = Width / 2;
            var rShortHandMesureStart = (float)(center * 0.85);
            var rShortHandMesureEnd = (float)(center * 0.99);

            for (int j=0;j<12;j++)
            {
                var shitaMin = (j+3) * Math.PI / 6;

                canvas.DrawLine(
                    (float)(center - rShortHandMesureStart * Math.Cos(shitaMin)),
                    (float)(center - rShortHandMesureStart * Math.Sin(shitaMin)),
                    (float)(center - rShortHandMesureEnd * Math.Cos(shitaMin)),
                    (float)(center - rShortHandMesureEnd * Math.Sin(shitaMin)),
                    paint);

            }
            
        }

        private void drawClockSecHand(Canvas canvas, Paint paint)
        {
            paint.AntiAlias = true;
            paint.StrokeWidth = 25;

            var center = Width / 2;
            var rLongHand = (float)(center * 0.79);
            var now = DateTime_Now;

            //秒針
            var shitaMin = (now.Second + 15) * Math.PI / 30;
            paint.Color = Color.Red;
            canvas.DrawLine(
                center,
                center,
                (float)(center - rLongHand * Math.Cos(shitaMin)),
                (float)(center - rLongHand * Math.Sin(shitaMin)),
                paint);

        }

        private void drawClockHand(Canvas canvas, Paint paint)
        {
            paint.AntiAlias = true;
            paint.StrokeWidth = 40;

            var center = Width / 2;
            var rShortHand = (float)(center * 0.60);
            var rLongHand = (float)(center * 0.80);
            var now = DateTime_Now;

            //長針
            var shitaMin = (now.Minute+15) * Math.PI / 30;
            paint.Color = Color.Green;
            canvas.DrawLine(
                center,
                center,
                (float)(center - rLongHand * Math.Cos(shitaMin)),
                (float)(center - rLongHand * Math.Sin(shitaMin)),
                paint);


            //短針
            var shitaHour = (((now.Hour % 12 + 3) * 60 + now.Minute)* Math.PI) / 360;

            paint.SetStyle(Paint.Style.Fill);//スタイルを線描画に設定
            paint.Color = Color.Orange;
            canvas.DrawLine(center,
                center, 
                (float)(center - rShortHand * Math.Cos(shitaHour)),
                (float)(center - rShortHand * Math.Sin(shitaHour)),
                paint);

        }

        private void clockcenter(Canvas canvas, Paint paint)
        {
            paint.AntiAlias = true;

            var center = Width / 2;
            var r = (float)(center * 0.15);

            paint.SetStyle(Paint.Style.Fill);//スタイルを線描画に設定
            paint.Color = new Color(0x49, 0x71, 0xFF);
            canvas.DrawCircle(center, center, r, paint);
        }

        private void clockcircle(Canvas canvas,Paint paint)
        {
            paint.AntiAlias = true;

            var center = Width / 2;
            var r = (float)(center * 0.95);

            paint.SetStyle(Paint.Style.Fill);//スタイルを線描画に設定
            paint.Color = Color.White;
            canvas.DrawCircle(center, center, r, paint);

            paint.SetStyle(Paint.Style.Stroke);//スタイルを線描画に設定
            paint.StrokeWidth = 40;
            paint.Color  = new Color(0x49,0x71,0xFF);
            if(drucking) paint.Color = Color.Pink;

            canvas.DrawCircle(center, center,  r , paint);

        }

        private void createmesh(Canvas canvas, Paint paint)
        {
            paint.AntiAlias = false;
            paint.SetStyle(Paint.Style.Stroke);//スタイルを線描画に設定
            paint.StrokeWidth = 1;//線の太さ 15pt
            paint.Color = Color.White;// 線を白色にする

            for (int y = 0; y < canvas.Height ; y += 100)
            {
                canvas.DrawLine(0, y, canvas.Width, y, paint);
            }

            for (int x = 0; x < canvas.Width; x += 100)
            {
                canvas.DrawLine(x, 0, x, canvas.Height, paint);
            }

        }

        private void TestDraw1(Canvas canvas, Paint paint)
        {
            //直線(ライン端がブッチで白色の線)
            var x = 20;
            var y = 40;
            paint.AntiAlias = true;//アンチエイリアス有効
            paint.SetStyle(Paint.Style.Stroke);//スタイルを線描画に設定
            paint.StrokeWidth = 15;//線の太さ 15pt
            paint.Color = Color.White;// 線を白色にする
            paint.StrokeCap = Paint.Cap.Butt;//ラインキャップ（ブッチ）四角と比べて頂点に四角を描画しない分短くなる
            canvas.DrawLine(x, y, x + 80, y + 80, paint);//描画

            //直線(ライン端が丸で青色の線)
            x += 90;//右へずらす
            paint.Color = Color.Blue;// 線を青色にする
            paint.StrokeCap = Paint.Cap.Round;//ラインキャップ（丸）
            canvas.DrawLine(x, y, x + 80, y + 80, paint);//描画

            //直線(ライン端が四角で緑色の線)
            x += 90;//右へずらす
            paint.Color = Color.Green;// 線を緑色にする
            paint.StrokeCap = Paint.Cap.Square;//ラインキャップ（四角）
            canvas.DrawLine(x, y, x + 80, y + 80, paint);//描画

            //折れ線(継ぎ目が斜め継ぎで赤色の折れ線)
            x = 20;
            y = 130;
            paint.StrokeWidth = 20;//線の太さ 20pt
            paint.Color = Color.Red;// 線を赤色にする
            paint.StrokeJoin = Paint.Join.Miter;//接続部形状（斜め継ぎ）
            var path = new Path();
            path.MoveTo(x, y);// 始点
            path.LineTo(x + 80, y + 80);//中継点
            path.LineTo(x + 140, y + 40);//中継点
            canvas.DrawPath(path, paint);//描画

            //折れ線(継ぎ目がべベルでオレンジ色の折れ線)
            y += 90;//下へずらす
            paint.Color = Color.Orange;// 線をオレンジ色にする
            paint.StrokeJoin = Paint.Join.Bevel;//接続部形状（べベル）
            path.Reset();//パスのリセット
            path.MoveTo(x, y);// 始点
            path.LineTo(x + 80, y + 80);//中継点
            path.LineTo(x + 140, y + 40);//中継点
            canvas.DrawPath(path, paint);//描画

            //折れ線(継ぎ目が丸で茶色の折れ線)
            y += 90;//下へずらす
            paint.Color = Color.Brown;// 線を茶色にする
            paint.StrokeJoin = Paint.Join.Round;//接続部形状（丸）
            path.Reset();//パスのリセット
            path.MoveTo(x, y);// 始点
            path.LineTo(x + 80, y + 80);//中継点
            path.LineTo(x + 140, y + 40);//中継点
            canvas.DrawPath(path, paint);//描画

            //折れ線(紫色の閉じられた折れ線)
            y += 90;//下へずらす
            paint.Color = Color.Magenta;// 線を紫色にする
            paint.StrokeJoin = Paint.Join.Miter;//接続部形状（斜め継ぎ）
            path.Reset();//パスのリセット
            path.MoveTo(x, y);// 始点
            path.LineTo(x + 80, y + 80);//中継点
            path.LineTo(x + 140, y + 40);//中継点
            path.Close();//折れ線を閉じる
            canvas.DrawPath(path, paint);//描画

            //直線(２ドットの点線)
            x = 20;
            y = 540;
            paint.StrokeWidth = 2;//線の太さ 2pt
            paint.Color = Color.White;// 線を白色にする
            var dash = new float[] { 2, 2 };//パターン ■■□□■■□□
            paint.SetPathEffect(new DashPathEffect(dash, 0));
            canvas.DrawLine(x, y, x + 80, y + 80, paint);//描画

            //直線（１０ドット（空白４ドット）の破線）
            x += 80;//右へずらす
            dash = new float[] { 10, 4 };//パターン ■■■■■■■■■■□□□□
            paint.SetPathEffect(new DashPathEffect(dash, 0));
            canvas.DrawLine(x, y, x + 80, y + 80, paint);//描画

            //直線（１０ドットと５ドットの一点破線）
            x += 80;//右へずらす
            dash = new float[] { 10, 4, 5, 4 };//パターン ■■■■■■■■■■□□□□■■■■■□□□□
            paint.SetPathEffect(new DashPathEffect(dash, 0));
            canvas.DrawLine(x, y, x + 80, y + 80, paint);//描画

            //直線（１０ドットと５ドットの一点破線）線の太さ3
            x += 80;//右へずらす
            paint.StrokeWidth = 3;//線の太さ 3pt
            dash = new float[] { 10, 4, 5, 4 };//パターン ■■■■■■■■■■□□□□■■■■■□□□□
            paint.SetPathEffect(new DashPathEffect(dash, 0));
            canvas.DrawLine(x, y, x + 80, y + 80, paint);//描画
        }

    }
}