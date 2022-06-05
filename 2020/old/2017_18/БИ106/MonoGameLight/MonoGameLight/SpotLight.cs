using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameLight
{
    public class SpotLight : Sprite
    {
        public Color LightColor;


        public SpotLight(Texture2D tex) 
            : base(tex)
        {
            LightColor = Color.Gold;
        }

        public override void Draw(SpriteBatch batch)
        {
            // при рисовании светового
            // пятна - НАЛОЖИТЬ эффект
            // аддитивное смешивание 
            // Add - сложить
            batch.Begin(SpriteSortMode.Deferred, BlendState.Additive);
            batch.Draw(_tex, // картинка
                       _pos, // положение
                       null, // прямоуг вырезания
                       LightColor, // цвет смешивания
                       _angle, // угол поворота
                       _origin, // точка поворота
                       _scale, // коэф масштабирования
                       SpriteEffects.None, // зеркалирование
                       1 // номер слоя
                       );
            batch.End();
        }
    }
}
