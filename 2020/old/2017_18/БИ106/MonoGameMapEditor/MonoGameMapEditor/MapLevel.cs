using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace MonoGameMapEditor
{
    public enum CellType
    {
        Empty,
        Wall,
        Water,
        Forest  
    }

    public class MapLevel :
        DrawableGameComponent
    {
        private Vector2 _srcCellSize;

        private float _currentScale;

        public void Save(string fname)
        {
            var fs = new FileStream(fname, FileMode.Create);
            // запишем в файл 
            // 8 байт - ширина (int) и высота (int)
            byte[] bytes = BitConverter.GetBytes(_map.GetLength(1));
            fs.Write(bytes, 0, bytes.Length);
            bytes = BitConverter.GetBytes(_map.GetLength(0));
            fs.Write(bytes, 0, bytes.Length);
            // записываем все основные байты массива
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    fs.WriteByte(_map[i,j]);
                }
            }
            fs.Flush();
            fs.Close();
        }

        public void Load(string fname)
        {
            var fs = new FileStream(fname, FileMode.Open);
            // считываем из файл 
            // 8 байт - ширина (int) и высота (int)
            byte[] bytes = new byte[4];
            fs.Read(bytes,0,4);
            int width = BitConverter.ToInt32(bytes,0);
            fs.Read(bytes, 0, 4);
            int height = BitConverter.ToInt32(bytes, 0);
            _map = new byte[height, width];
            // считываем все основные байты массива
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    _map[i,j] =(byte) fs.ReadByte();
                }
            }
            fs.Close();
        }

        public byte[,] GetCells()
        {
            return _map;
        }

        // прямоугольник, описывает
        // видимую часть карты
        private Rectangle _viewRect;

        private byte[,] _map;
        private int _rows, _cols;
        private Dictionary<CellType, Texture2D> _dictTex;
        private SpriteBatch _batch;
        private Vector2 _cellSize;

        public float CellWidth
        {
            get
            {
                return _cellSize.X;
            }
        }
        public float CellHeight
        {
            get
            {
                return _cellSize.Y;
            }
        }

        public int ViewX
        {
            get
            {
                return _viewRect.X;
            }
        }
        public int ViewY
        {
            get
            {
                return _viewRect.Y;
            }
        }

        public void Scale(float percent)
        {
            _currentScale += percent;
            if (_currentScale < 0.1f)
            {
                _currentScale = 0.1f;
            }

            _cellSize.X = _srcCellSize.X * _currentScale;
            _cellSize.Y = _srcCellSize.Y * _currentScale;

            int sx = Game.Window.ClientBounds.Width;
            int sy = Game.Window.ClientBounds.Height;
            _viewRect.Width = (int)(sx / _cellSize.X) + 1;
            _viewRect.Height = (int)(sy / _cellSize.Y) + 1;
            if (_viewRect.Width > _cols)
            {
                _viewRect.Width = _cols;
            }
            if (_viewRect.Height > _rows)
            {
                _viewRect.Height = _rows;
            }
        }

        public void Scroll(int dx, int dy)
        {
            _viewRect.X += dx;
            _viewRect.Y += dy;
            //------------------
            if (_viewRect.Left < 0)
                _viewRect.X = 0;
            if (_viewRect.Top < 0)
                _viewRect.Y = 0;
            //------------------
            if (_viewRect.Right > _cols)
                _viewRect.X -= dx;
            if (_viewRect.Bottom > _rows)
                _viewRect.Y -= dy;
        }

        public MapLevel(Game game)
            :base(game)
        {
            game.Components.Add(this);
            _dictTex = new Dictionary<CellType, Texture2D>();
            _cellSize = new Vector2(50,50);
            _srcCellSize = new Vector2(50,50);
            _viewRect = new Rectangle(0, 0, 1, 1);
            _currentScale = 1.0f;
            
        }

        protected override void LoadContent()
        {
            _batch = new SpriteBatch(Game.GraphicsDevice);
            // 1) из перечисления взять
            // массив названий в виде строк
            // Load("Forest")
            string[] names =
             Enum.GetNames(typeof(CellType));
            // 2) загружаем все текстуры
            for (int i = 0; i < names.Length; i++)
            {
                Texture2D tex =
                Game.Content.Load<Texture2D>
                    (names[i]);
                CellType key = (CellType)i;
                // складываем в словарь
                _dictTex.Add(key, tex);
            }
        }

        public void SetSize(int rows, int cols)
        {
            _map = new byte[rows, cols];
            _rows = rows;
            _cols = cols;
            _map[1, 1] = (int) CellType.Wall;
            _map[5, 7] = (int)CellType.Wall;
            _map[10, 10] = (int)CellType.Wall;
            Scale(0);
        }

        public override void Draw(GameTime gameTime)
        {
            var rct = new Rectangle();
            rct.X = 0;
            rct.Y = 0;
            rct.Width = (int) _cellSize.X;
            rct.Height = (int) _cellSize.Y;
            //----------------------------
            _batch.Begin();
            for (int i = _viewRect.Top; i < _viewRect.Bottom; i++)
            {
                for (int j = _viewRect.Left; j < _viewRect.Right; j++)
                {
                    int ntype = _map[i,j];
                    CellType ct = (CellType)ntype;
                    Texture2D tex = _dictTex[ct];
                    rct.X = (int)((j - _viewRect.Left) * _cellSize.X);
                    rct.Y = (int)((i - _viewRect.Top) * _cellSize.Y);
                    _batch.Draw(tex, rct, Color.White);
                }
            }
            _batch.End();
        }
    }
}
