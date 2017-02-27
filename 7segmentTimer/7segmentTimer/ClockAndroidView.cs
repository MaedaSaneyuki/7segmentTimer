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


            //���j
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

            paint.SetStyle(Paint.Style.Fill);//�X�^�C������`��ɐݒ�
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

            //�b�j
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

            //���j
            var shitaMin = (now.Minute+15) * Math.PI / 30;
            paint.Color = Color.Green;
            canvas.DrawLine(
                center,
                center,
                (float)(center - rLongHand * Math.Cos(shitaMin)),
                (float)(center - rLongHand * Math.Sin(shitaMin)),
                paint);


            //�Z�j
            var shitaHour = (((now.Hour % 12 + 3) * 60 + now.Minute)* Math.PI) / 360;

            paint.SetStyle(Paint.Style.Fill);//�X�^�C������`��ɐݒ�
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

            paint.SetStyle(Paint.Style.Fill);//�X�^�C������`��ɐݒ�
            paint.Color = new Color(0x49, 0x71, 0xFF);
            canvas.DrawCircle(center, center, r, paint);
        }

        private void clockcircle(Canvas canvas,Paint paint)
        {
            paint.AntiAlias = true;

            var center = Width / 2;
            var r = (float)(center * 0.95);

            paint.SetStyle(Paint.Style.Fill);//�X�^�C������`��ɐݒ�
            paint.Color = Color.White;
            canvas.DrawCircle(center, center, r, paint);

            paint.SetStyle(Paint.Style.Stroke);//�X�^�C������`��ɐݒ�
            paint.StrokeWidth = 40;
            paint.Color  = new Color(0x49,0x71,0xFF);
            if(drucking) paint.Color = Color.Pink;

            canvas.DrawCircle(center, center,  r , paint);

        }

        private void createmesh(Canvas canvas, Paint paint)
        {
            paint.AntiAlias = false;
            paint.SetStyle(Paint.Style.Stroke);//�X�^�C������`��ɐݒ�
            paint.StrokeWidth = 1;//���̑��� 15pt
            paint.Color = Color.White;// ���𔒐F�ɂ���

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
            //����(���C���[���u�b�`�Ŕ��F�̐�)
            var x = 20;
            var y = 40;
            paint.AntiAlias = true;//�A���`�G�C���A�X�L��
            paint.SetStyle(Paint.Style.Stroke);//�X�^�C������`��ɐݒ�
            paint.StrokeWidth = 15;//���̑��� 15pt
            paint.Color = Color.White;// ���𔒐F�ɂ���
            paint.StrokeCap = Paint.Cap.Butt;//���C���L���b�v�i�u�b�`�j�l�p�Ɣ�ׂĒ��_�Ɏl�p��`�悵�Ȃ����Z���Ȃ�
            canvas.DrawLine(x, y, x + 80, y + 80, paint);//�`��

            //����(���C���[���ۂŐF�̐�)
            x += 90;//�E�ւ��炷
            paint.Color = Color.Blue;// ����F�ɂ���
            paint.StrokeCap = Paint.Cap.Round;//���C���L���b�v�i�ہj
            canvas.DrawLine(x, y, x + 80, y + 80, paint);//�`��

            //����(���C���[���l�p�ŗΐF�̐�)
            x += 90;//�E�ւ��炷
            paint.Color = Color.Green;// ����ΐF�ɂ���
            paint.StrokeCap = Paint.Cap.Square;//���C���L���b�v�i�l�p�j
            canvas.DrawLine(x, y, x + 80, y + 80, paint);//�`��

            //�܂��(�p���ڂ��΂ߌp���ŐԐF�̐܂��)
            x = 20;
            y = 130;
            paint.StrokeWidth = 20;//���̑��� 20pt
            paint.Color = Color.Red;// ����ԐF�ɂ���
            paint.StrokeJoin = Paint.Join.Miter;//�ڑ����`��i�΂ߌp���j
            var path = new Path();
            path.MoveTo(x, y);// �n�_
            path.LineTo(x + 80, y + 80);//���p�_
            path.LineTo(x + 140, y + 40);//���p�_
            canvas.DrawPath(path, paint);//�`��

            //�܂��(�p���ڂ��׃x���ŃI�����W�F�̐܂��)
            y += 90;//���ւ��炷
            paint.Color = Color.Orange;// �����I�����W�F�ɂ���
            paint.StrokeJoin = Paint.Join.Bevel;//�ڑ����`��i�׃x���j
            path.Reset();//�p�X�̃��Z�b�g
            path.MoveTo(x, y);// �n�_
            path.LineTo(x + 80, y + 80);//���p�_
            path.LineTo(x + 140, y + 40);//���p�_
            canvas.DrawPath(path, paint);//�`��

            //�܂��(�p���ڂ��ۂŒ��F�̐܂��)
            y += 90;//���ւ��炷
            paint.Color = Color.Brown;// ���𒃐F�ɂ���
            paint.StrokeJoin = Paint.Join.Round;//�ڑ����`��i�ہj
            path.Reset();//�p�X�̃��Z�b�g
            path.MoveTo(x, y);// �n�_
            path.LineTo(x + 80, y + 80);//���p�_
            path.LineTo(x + 140, y + 40);//���p�_
            canvas.DrawPath(path, paint);//�`��

            //�܂��(���F�̕���ꂽ�܂��)
            y += 90;//���ւ��炷
            paint.Color = Color.Magenta;// �������F�ɂ���
            paint.StrokeJoin = Paint.Join.Miter;//�ڑ����`��i�΂ߌp���j
            path.Reset();//�p�X�̃��Z�b�g
            path.MoveTo(x, y);// �n�_
            path.LineTo(x + 80, y + 80);//���p�_
            path.LineTo(x + 140, y + 40);//���p�_
            path.Close();//�܂�������
            canvas.DrawPath(path, paint);//�`��

            //����(�Q�h�b�g�̓_��)
            x = 20;
            y = 540;
            paint.StrokeWidth = 2;//���̑��� 2pt
            paint.Color = Color.White;// ���𔒐F�ɂ���
            var dash = new float[] { 2, 2 };//�p�^�[�� ����������������
            paint.SetPathEffect(new DashPathEffect(dash, 0));
            canvas.DrawLine(x, y, x + 80, y + 80, paint);//�`��

            //�����i�P�O�h�b�g�i�󔒂S�h�b�g�j�̔j���j
            x += 80;//�E�ւ��炷
            dash = new float[] { 10, 4 };//�p�^�[�� ����������������������������
            paint.SetPathEffect(new DashPathEffect(dash, 0));
            canvas.DrawLine(x, y, x + 80, y + 80, paint);//�`��

            //�����i�P�O�h�b�g�ƂT�h�b�g�̈�_�j���j
            x += 80;//�E�ւ��炷
            dash = new float[] { 10, 4, 5, 4 };//�p�^�[�� ����������������������������������������������
            paint.SetPathEffect(new DashPathEffect(dash, 0));
            canvas.DrawLine(x, y, x + 80, y + 80, paint);//�`��

            //�����i�P�O�h�b�g�ƂT�h�b�g�̈�_�j���j���̑���3
            x += 80;//�E�ւ��炷
            paint.StrokeWidth = 3;//���̑��� 3pt
            dash = new float[] { 10, 4, 5, 4 };//�p�^�[�� ����������������������������������������������
            paint.SetPathEffect(new DashPathEffect(dash, 0));
            canvas.DrawLine(x, y, x + 80, y + 80, paint);//�`��
        }

    }
}