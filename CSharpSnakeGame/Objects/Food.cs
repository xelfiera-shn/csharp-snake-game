using CSharpSnakeGame.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSnakeGame.Objects
{
    public class Food : Scheme
    {
        Random random = new Random();

        public Food()
        {
            this.Image = Resources.apple;
        }

        public void GenerateNewLocation(Snake snake)
        {
            int foodX = random.Next((1200 / 40) - 1);
            int foodY = random.Next((800 / 40) - 1);

            foreach (BodyPart part in snake.BodyParts)
            {
                if (foodX == part.Location.X && foodY == part.Location.Y)
                    GenerateNewLocation(snake);
            }

            this.Location = new Point(foodX * 40, foodY * 40);
        }
    }
}
