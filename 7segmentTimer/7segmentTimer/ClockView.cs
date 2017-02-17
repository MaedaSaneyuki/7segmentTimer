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


namespace _7segmentTimer
{
    class ClockView : View
    {
        public ClockView(Context context) : base(context) { }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);
            using (var paint = new Paint())
            {
                TestDraw1(canvas, paint);
                clockcircle(canvas, paint);


                clockcenter(canvas, paint);
                createmesh(canvas, paint);
            }
        }

        

        private void clockcenter(Canvas canvas, Paint paint)
        {
            paint.AntiAlias = true;

            var center = Width / 2;
            var r = 60;

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