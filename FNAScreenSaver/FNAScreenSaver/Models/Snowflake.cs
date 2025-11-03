using FNAScreenSaver.Constants;

namespace FNAScreenSaver.Models
{
    /// <summary>
    /// Модель снежинки
    /// </summary>
    public class Snowflake
    {
        /// <summary>
        /// Координата X
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Координата Y
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Скорость снежинки
        /// </summary>
        public float Speed { get; set; }

        /// <summary>
        /// Масштаб снежинки
        /// </summary>
        public float Scale { get; set; }

        /// <summary>
        /// Цвет снежинки
        /// </summary>
        public Microsoft.Xna.Framework.Color Color { get; set; } = Microsoft.Xna.Framework.Color.White;

        /// <summary>
        /// Обновляет позицию снежинки
        /// </summary>
        public void Update(float deltaTime)
        {
            Y += Speed * deltaTime;
        }

        /// <summary>
        /// Сбрасывает снежинку в начальное положение
        /// </summary>
        public void Reset(int startPosition)
        {
            Y = -Random.Shared.Next(SnowflakeConstants.MinStartY, SnowflakeConstants.MaxStartY);
            X = Random.Shared.Next(0, (int)startPosition);

            Speed = Random.Shared.NextSingle() *
                     (SnowflakeConstants.MaxSpeed - SnowflakeConstants.MinSpeed) + SnowflakeConstants.MinSpeed;

            Scale = Random.Shared.NextSingle() *
                     (SnowflakeConstants.MaxScale - SnowflakeConstants.MinScale) + SnowflakeConstants.MinScale;

            var alpha = Random.Shared.NextSingle() *
                          (SnowflakeConstants.MaxAlpha - SnowflakeConstants.MinAlpha) + SnowflakeConstants.MinAlpha;

            Color = new Microsoft.Xna.Framework.Color(1f, 1f, 1f, alpha);
        }
    }
}
