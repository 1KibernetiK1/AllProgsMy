using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameMapEditor
{
    public class MapEditor :
        GameComponent
    {
        private MapLevel _map;
        private byte[,] _cells;

        public MapEditor(Game game, MapLevel map) 
            : base(game)
        {
            _map = map;
            _cells = _map.GetCells();
            game.Components.Add(this);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.F5))
            {
                _map.Save("level01.lvl");
            }
            if (ks.IsKeyDown(Keys.F6))
            {
                _map.Load("level01.lvl");
                _cells = _map.GetCells();
            }

            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed)
            {
                // вычисляем координаты ячеек
                int c =(int) ( ms.X / _map.CellWidth  +_map.ViewX );
                int r =(int) ( ms.Y / _map.CellHeight +_map.ViewY );
                _cells[r, c] = (int)CellType.Wall;
            }
            if (ms.RightButton == ButtonState.Pressed)
            {
                // вычисляем координаты ячеек
                int c = (int)(ms.X / _map.CellWidth + _map.ViewX);
                int r = (int)(ms.Y / _map.CellHeight + _map.ViewY);
                _cells[r, c] = (int)CellType.Empty;
            }
        }
    }
}
