using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class Matrix4x4
    {
        public float[,] m = new float[4, 4];

        public Matrix4x4()
        {
            
        }

        public static Matrix4x4 Identity
        {
            get
            {
                Matrix4x4 m4 = new Matrix4x4();

                m4.m[0, 0] = 1f;
                m4.m[1, 1] = 1f;
                m4.m[2, 2] = 1f;
                m4.m[3, 3] = 1f;

                return m4;
            }
        }

        public float Determinant
        {
            get
            {
                var matrix = new Matrix4x4 { };
                float d = matrix.m[0,0] *
                    (matrix.m[1,1] * (matrix.m[2,2] * matrix.m[3,3] - matrix.m[3,2] * matrix.m[2,3]) +
                    matrix.m[2,1] * -1 * (matrix.m[1,2] * matrix.m[3,3] - matrix.m[3,2] * matrix.m[1,3]) +
                    matrix.m[3,1] * (matrix.m[1,2] * matrix.m[2,3] - matrix.m[2,2] * matrix.m[1,3])) +
                    matrix.m[1,0] *
                    (matrix.m[0,1] * (matrix.m[2,2] * matrix.m[3,3] - matrix.m[3,2] * matrix.m[2,3]) +
                    matrix.m[2,1] * -1 * (matrix.m[0,2] * matrix.m[3,3] - matrix.m[3,2] * matrix.m[0,3]) +
                    matrix.m[3,1] * (matrix.m[0,2] * matrix.m[2,3] - matrix.m[2,2] * matrix.m[0,3])) +
                    matrix.m[2,0] *
                    (matrix.m[0,1] * (matrix.m[1,2] * matrix.m[3,3] - matrix.m[3,2] * matrix.m[1,3]) +
                    matrix.m[1,1] * -1 * (matrix.m[0,2] * matrix.m[3,3] - matrix.m[3,2] * matrix.m[0,3]) +
                    matrix.m[3,1] * (matrix.m[0,2] * matrix.m[1,3] - matrix.m[1,2] * matrix.m[0,3])) +
                    matrix.m[3,0] *
                    (matrix.m[0,1] * (matrix.m[1,2] * matrix.m[2,3] - matrix.m[2,2] * matrix.m[1,3]) +
                    matrix.m[1,1] * -1 * (matrix.m[0,2] * matrix.m[2,3] - matrix.m[2,2] * matrix.m[0,3]) +
                    matrix.m[2,1] * (matrix.m[0,2] * matrix.m[1,3] - matrix.m[1,2] * matrix.m[0,3]));
                return d;
            }
        }

        public Matrix4x4 Inverse
        {
            get { throw new NotImplementedException(); }
        }

        public static Matrix4x4 Translate(Vector3 translation)
        {
            Matrix4x4 m4 = new Matrix4x4();

            m4.m[3, 0] = translation.x;
            m4.m[3, 1] = translation.y;
            m4.m[3, 2] = translation.z;
            m4.m[3, 3] = 1;

            return m4;
        }

        public static Matrix4x4 Rotate(Vector3 rotation)
        {
            {
                var matrix = new Matrix4x4 { };
                matrix = Identity;
                matrix *= RotateZ(rotation.z);
                matrix *= RotateX(rotation.x);
                matrix *= RotateY(rotation.y);
                return matrix;
            }
        }

        public static Matrix4x4 RotateX(float rotation)
        {
            var matrix = new Matrix4x4 { };
            matrix = Identity;
            matrix.m[0,0] = (float)Math.Cos(rotation);
            matrix.m[0,1] = -(float)Math.Sin(rotation);
            matrix.m[1,0] = (float)Math.Sin(rotation);
            matrix.m[1,1] = (float)Math.Cos(rotation);
            return matrix;
        }

        public static Matrix4x4 RotateY(float rotation)
        {
            var matrix = new Matrix4x4 { };
            matrix = Identity;
            matrix.m[0,0] = (float)Math.Cos(rotation);
            matrix.m[0,2] = -(float)Math.Sin(rotation);
            matrix.m[2,0] = (float)Math.Sin(rotation);
            matrix.m[2,2] = (float)Math.Cos(rotation);
            return matrix;
        }

        public static Matrix4x4 RotateZ(float rotation)
        {
            var matrix = new Matrix4x4 { };
            matrix = Identity;
            matrix.m[1,1] = (float)Math.Cos(rotation);
            matrix.m[1,2] = -(float)Math.Sin(rotation);
            matrix.m[2,1] = (float)Math.Sin(rotation);
            matrix.m[2,2] = (float)Math.Cos(rotation);
            return matrix;
            throw new NotImplementedException();
        }

        public static Matrix4x4 Scale(Vector3 scale)
        {
            Matrix4x4 m4 = new Matrix4x4();

            m4.m[0, 0] = scale.x;
            m4.m[1, 1] = scale.y;
            m4.m[2, 2] = scale.z;
            m4.m[3, 3] = 1;

            return m4;
        }

        public static Matrix4x4 operator *(Matrix4x4 lhs, Matrix4x4 rhs)
        {
            Matrix4x4 m4 = new Matrix4x4();

            m4.m[0, 0] = (lhs.m[0, 0] * rhs.m[0, 0]) + (lhs.m[1, 0] * rhs.m[0, 1]) + (lhs.m[2, 0] * rhs.m[0, 2]) + (lhs.m[3, 0] * rhs.m[0, 3]);
            m4.m[1, 0] = (lhs.m[0, 0] * rhs.m[1, 0]) + (lhs.m[1, 0] * rhs.m[1, 1]) + (lhs.m[2, 0] * rhs.m[1, 2]) + (lhs.m[3, 0] * rhs.m[1, 3]);
            m4.m[2, 0] = (lhs.m[0, 0] * rhs.m[2, 0]) + (lhs.m[1, 0] * rhs.m[2, 1]) + (lhs.m[2, 0] * rhs.m[2, 2]) + (lhs.m[3, 0] * rhs.m[2, 3]);
            m4.m[3, 0] = (lhs.m[0, 0] * rhs.m[3, 0]) + (lhs.m[1, 0] * rhs.m[3, 1]) + (lhs.m[2, 0] * rhs.m[3, 2]) + (lhs.m[3, 0] * rhs.m[3, 3]);

            m4.m[0, 1] = (lhs.m[0, 1] * rhs.m[0, 0]) + (lhs.m[1, 1] * rhs.m[0, 1]) + (lhs.m[2, 1] * rhs.m[0, 2]) + (lhs.m[3, 1] * rhs.m[0, 3]);
            m4.m[1, 1] = (lhs.m[0, 1] * rhs.m[1, 0]) + (lhs.m[1, 1] * rhs.m[1, 1]) + (lhs.m[2, 1] * rhs.m[1, 2]) + (lhs.m[3, 1] * rhs.m[1, 3]);
            m4.m[2, 1] = (lhs.m[0, 1] * rhs.m[2, 0]) + (lhs.m[1, 1] * rhs.m[2, 1]) + (lhs.m[2, 1] * rhs.m[2, 2]) + (lhs.m[3, 1] * rhs.m[2, 3]);
            m4.m[3, 1] = (lhs.m[0, 1] * rhs.m[3, 0]) + (lhs.m[1, 1] * rhs.m[3, 1]) + (lhs.m[2, 1] * rhs.m[3, 2]) + (lhs.m[3, 1] * rhs.m[3, 3]);

            m4.m[0, 2] = (lhs.m[0, 2] * rhs.m[0, 0]) + (lhs.m[1, 2] * rhs.m[0, 1]) + (lhs.m[2, 2] * rhs.m[0, 2]) + (lhs.m[3, 2] * rhs.m[0, 3]);
            m4.m[1, 2] = (lhs.m[0, 2] * rhs.m[1, 0]) + (lhs.m[1, 2] * rhs.m[1, 1]) + (lhs.m[2, 2] * rhs.m[1, 2]) + (lhs.m[3, 2] * rhs.m[1, 3]);
            m4.m[2, 2] = (lhs.m[0, 2] * rhs.m[2, 0]) + (lhs.m[1, 2] * rhs.m[2, 1]) + (lhs.m[2, 2] * rhs.m[2, 2]) + (lhs.m[3, 2] * rhs.m[2, 3]);
            m4.m[3, 2] = (lhs.m[0, 2] * rhs.m[3, 0]) + (lhs.m[1, 2] * rhs.m[3, 1]) + (lhs.m[2, 2] * rhs.m[3, 2]) + (lhs.m[3, 2] * rhs.m[3, 3]);

            m4.m[0, 3] = (lhs.m[0, 3] * rhs.m[0, 0]) + (lhs.m[1, 3] * rhs.m[0, 1]) + (lhs.m[2, 3] * rhs.m[0, 2]) + (lhs.m[3, 3] * rhs.m[0, 3]);
            m4.m[1, 3] = (lhs.m[0, 3] * rhs.m[1, 0]) + (lhs.m[1, 3] * rhs.m[1, 1]) + (lhs.m[2, 3] * rhs.m[1, 2]) + (lhs.m[3, 3] * rhs.m[1, 3]);
            m4.m[2, 3] = (lhs.m[0, 3] * rhs.m[2, 0]) + (lhs.m[1, 3] * rhs.m[2, 1]) + (lhs.m[2, 3] * rhs.m[2, 2]) + (lhs.m[3, 3] * rhs.m[2, 3]);
            m4.m[3, 3] = (lhs.m[0, 3] * rhs.m[3, 0]) + (lhs.m[1, 3] * rhs.m[3, 1]) + (lhs.m[2, 3] * rhs.m[3, 2]) + (lhs.m[3, 3] * rhs.m[3, 3]);

            return m4;
        }

        public static Vector4 operator *(Matrix4x4 lhs, Vector4 rhs)
        {
            var vector = new Vector4 { };
            vector.x = lhs.m[0,0] * vector.x + lhs.m[1,0] * vector.y + lhs.m[2,0] * vector.z + lhs.m[3,0] * vector.w;
            vector.y = lhs.m[0,1] * vector.x + lhs.m[1,1] * vector.y + lhs.m[2,1] * vector.z + lhs.m[3,1] * vector.w;
            vector.z = lhs.m[0,2] * vector.x + lhs.m[1,2] * vector.y + lhs.m[2,2] * vector.z + lhs.m[3,2] * vector.w;
            vector.w = lhs.m[0,3] * vector.x + lhs.m[1,3] * vector.y + lhs.m[2,3] * vector.z + lhs.m[3,3] * vector.w;
            return vector;
        }
    }
}
