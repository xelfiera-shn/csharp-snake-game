using CSharpSnakeGame.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSnakeGame.Objects
{
    public class Snake
    {
        private const int SPAWN_LOCATION_X = 600;
        private const int SPAWN_LOCATION_Y = 400;

        public List<BodyPart> BodyParts;
        private Point _spawnLocation = new Point(SPAWN_LOCATION_X, SPAWN_LOCATION_Y);

        public Directions Direction;

        public Snake()
        {
            BodyParts = new();
        }

        public bool Move(Panel canvas, Food food)
        {
            int headX = BodyParts.Last().Location.X;
            int headY = BodyParts.Last().Location.Y;

            BodyPart part = new BodyPart();

            switch (Direction)
            {
                case Directions.Up:
                    headY -= 40;
                    part.Image = Resources.head_up;
                    break;

                case Directions.Right:
                    headX += 40;
                    part.Image = Resources.head_right;
                    break;

                case Directions.Down:
                    headY += 40;
                    part.Image = Resources.head_down;
                    break;

                case Directions.Left:
                    headX -= 40;
                    part.Image = Resources.head_left;
                    break;
            }

            part.Location = new Point(headX, headY);
            BodyParts.Add(part);
            canvas.Controls.Add(part);
            SetBodyPartImage(Direction);

            if (BodyParts.Last().Location != food.Location)
            {
                canvas.Controls.Remove(BodyParts[0]);
                BodyParts.RemoveAt(0);

                if (BodyParts.Count >= 2)
                {
                    if (BodyParts.First().Location.Y < BodyParts[1].Location.Y) BodyParts.First().Image = Resources.tail_up;
                    else if (BodyParts.First().Location.Y > BodyParts[1].Location.Y) BodyParts.First().Image = Resources.tail_down;
                    else if (BodyParts.First().Location.X < BodyParts[1].Location.X) BodyParts.First().Image = Resources.tail_left;
                    else if (BodyParts.First().Location.X > BodyParts[1].Location.X) BodyParts.First().Image = Resources.tail_right;
                }

                return false;
            }

            return true;
        }

        public void SetBodyPartImage(Directions direction)
        {
            if (BodyParts.Count >= 3)
            {
                BodyPart curPart = BodyParts[BodyParts.Count - 2];
                BodyPart prePart = BodyParts[BodyParts.Count - 3];

                if (direction == Directions.Up)
                {
                    if (curPart.Location.Y < prePart.Location.Y)
                        BodyParts[BodyParts.Count - 2].Image = Resources.body_vertical;

                    else if (curPart.Location.X < prePart.Location.X)
                        BodyParts[BodyParts.Count - 2].Image = Resources.body_topright;

                    else if (curPart.Location.X > prePart.Location.X)
                        BodyParts[BodyParts.Count - 2].Image = Resources.body_topleft;
                }

                else if (direction == Directions.Right)
                {
                    if (curPart.Location.X > prePart.Location.X)
                        BodyParts[BodyParts.Count - 2].Image = Resources.body_horizontal;

                    else if (curPart.Location.Y < prePart.Location.Y)
                        BodyParts[BodyParts.Count - 2].Image = Resources.body_bottomright;

                    else if (curPart.Location.Y > prePart.Location.Y)
                        BodyParts[BodyParts.Count - 2].Image = Resources.body_topright;
                }

                else if (direction == Directions.Down)
                {
                    if (curPart.Location.Y > prePart.Location.Y)
                        BodyParts[BodyParts.Count - 2].Image = Resources.body_vertical;

                    else if(curPart.Location.X > prePart.Location.X)
                        BodyParts[BodyParts.Count - 2].Image = Resources.body_bottomleft;

                    else if(curPart.Location.X < prePart.Location.X)
                        BodyParts[BodyParts.Count - 2].Image = Resources.body_bottomright;
                }

                else if (direction == Directions.Left)
                {
                    if(curPart.Location.X < prePart.Location.X)
                        BodyParts[BodyParts.Count - 2].Image = Resources.body_horizontal;

                    else if(curPart.Location.Y > prePart.Location.Y)
                        BodyParts[BodyParts.Count - 2].Image = Resources.body_topleft;

                    else if(curPart.Location.Y < prePart.Location.Y)
                        BodyParts[BodyParts.Count - 2].Image = Resources.body_bottomleft;
                }
            }
        }

        public void ResetSnake(Panel canvas)
        {
            BodyPart _head = new();
            _head.Image = Resources.head_right;
            _head.Location = _spawnLocation;

            BodyPart _tail = new();
            _tail.Image = Resources.tail_left;
            _tail.Location = new Point(SPAWN_LOCATION_X - 40, SPAWN_LOCATION_Y);

            Direction = Directions.Right;
            BodyParts.Clear();
            BodyParts.Add(_head);
            BodyParts.Add(_tail);
            canvas.Controls.Add(_head);
            canvas.Controls.Add(_tail);
        }
    }
}
