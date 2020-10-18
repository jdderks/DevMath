using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class Rigidbody
    {
        public Vector2 Velocity
        {
            get; private set;
        }

        public float Acceleration 
        { 
            get; private set; 
        }

        public float mass = 1.0f;

        public float frictionCoefficient;
        public float normalForce;

        public void UpdateVelocityWithForce(Vector2 forceDirection, float forceNewton, float deltaTime)
        {
            Velocity -= -forceDirection * forceNewton * deltaTime * mass;
            Velocity *= (1 - deltaTime * frictionCoefficient);
        }
    }
}
