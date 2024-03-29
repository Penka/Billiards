﻿using System;
using Microsoft.Xna.Framework;

namespace BilliardsAI
{
    class Physics
    {
        public static bool DoesBallCollideWithOtherBall(Ball ball, Ball otherBall, out double collisionTime)
        {
            return DoesBallCollideWithOtherBall(ball, otherBall, out collisionTime, ball.Dir, otherBall.Dir, ball.Speed, otherBall.Speed);
        }

        public static bool DoesBallCollideWithOtherBall(Ball ball, Ball otherBall, out double collisionTime, 
                                                        Vector2 ballDir, Vector2 otherBallDir, float ballSpeed, float otherBallSpeed)
        {
            collisionTime = double.MaxValue;
            double dx = ball.Center.X - otherBall.Center.X;
            double dy = ball.Center.Y - otherBall.Center.Y;
            double dvx = ballDir.X * ballSpeed - otherBallDir.X * otherBallSpeed;
            double dvy = ballDir.Y * ballSpeed - otherBallDir.Y * otherBallSpeed;
            double r1 = Ball.Radius;
            double r2 = Ball.Radius;

            double d = (dx * dvx + dy * dvy) * (dx * dvx + dy * dvy) - (dvx * dvx + dvy * dvy) * (dx * dx + dy * dy - (r1 + r2) * (r1 + r2));

            if (d > 0.00005)
            {
                double t1 = -(dx * dvx + dy * dvy - Math.Sqrt(d)) / (dvx * dvx + dvy * dvy);
                double t2 = -(dx * dvx + dy * dvy + Math.Sqrt(d)) / (dvx * dvx + dvy * dvy);

                if (t1 > 0 || t2 > 0)
                {
                    if (t1 < collisionTime)
                    {
                        collisionTime = t1;
                    }
                    if (t2 < collisionTime)
                    {
                        collisionTime = t2;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
