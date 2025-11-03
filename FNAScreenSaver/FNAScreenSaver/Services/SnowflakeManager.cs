using FNAScreenSaver.Models;
using Microsoft.Xna.Framework;
using System;
namespace FNAScreenSaver.Services
{
    /// <summary>
    /// Класс управления снежинками
    /// </summary>
    public class SnowflakeManager
    {
        private readonly Snowflake[] snowflakes;
        private readonly float screenWidth;
        private readonly float screenHeight;

        /// <summary>
        /// Инициализировать новый экземпляр <see cref="SnowflakeManager"/>
        /// </summary>
        public SnowflakeManager(int count, float screenWidth, float screenHeight)
        {
            snowflakes = new Snowflake[count];
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

            InitializeSnowflakes();
        }

        private void InitializeSnowflakes()
        {
            for (int i = 0; i < snowflakes.Length; i++)
            {
                snowflakes[i] = new Snowflake();
                snowflakes[i].Reset((int)screenWidth);
            }
        }

        /// <summary>
        /// Обновляет состояние всех снежинок
        /// </summary>
        public void Update(GameTime gameTime)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (var snowflake in snowflakes)
            {
                if (snowflake.Y > screenHeight)
                {
                    snowflake.Reset((int)screenWidth);
                }
                else
                {
                    snowflake.Update(deltaTime);
                }
            }
        }

        /// <summary>
        /// Возвращает все снежинки для отрисовки
        /// </summary>
        public Snowflake[] GetAllSnowflakes()
        {
            return snowflakes;
        }
    }
}
