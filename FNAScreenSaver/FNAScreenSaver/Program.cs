using FNAScreenSaver.Services;

namespace FNAScreenSaver
{
    /// <summary>
    /// Класс запуска программы
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Точка входа программы
        /// </summary>
        static void Main(string[] args)
        {
            using (GameEngine game = new GameEngine())
            {
                game.Run();
            }
        }
    }

}
