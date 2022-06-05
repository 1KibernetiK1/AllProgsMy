using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPAtternState.Behaviors
{
    public class BehaviorGuardPerimeter : IState
    {
        private class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        private List<Point> _points;

        private List<IState> _states;

        private IEnumerator<Point> _enumeratorPoints;
        private IEnumerator<IState> _enumeratorStates;



        public char GetFace() => _enumeratorStates.Current.GetFace();

        public BehaviorGuardPerimeter(int Left, int Top, int width, int height, bool clockwise = true)
        {
            var p1 = new Point { X = Left, Y = Top };
            var p2 = new Point { X = Left+width, Y = Top };
            var p3 = new Point { X = Left+width, Y = Top+height };
            var p4 = new Point { X = Left, Y = Top+height };

            if (clockwise)
            {
                _points = new List<Point> { p1, p2, p3, p4 };
                _states = new List<IState>
                {
                new StateMoveRight(),
                new StaetMoveDown(),
                new StateMoveLeft(),
                new StateMoveUp()
                };
            }
            else
            {
                _points = new List<Point> { p4, p3, p2, p1 };
                _states = new List<IState>
                {
                new StateMoveRight(),
                new StaetMoveDown(),
                new StateMoveLeft(),
                new StateMoveUp()
                };
            }

            
        }

        public void Move(Widget widget)
        {
            if (_enumeratorPoints==null)
            {
                // Инициализация движения
                initializeBehavior(widget);
            }
            else
            {
                _enumeratorStates.Current.Move(widget);
                if (widget.X == _enumeratorPoints.Current.X && widget.Y == _enumeratorPoints.Current.Y) // триггер по координатам
                {
                    //Переключение на следующее состояние
                    SwitchState();
                }
            }
        }

        /// <summary>
        /// Перечеслитель зацикливания
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerator"></param>
        private void EnumerateCycle<T>(IEnumerator<T> enumerator) //bool shift
        {
            if (!enumerator.MoveNext())
            {
                //  Сбросить на начало - зациклить
                enumerator.Reset();
                enumerator.MoveNext();

                //if (shift) enumerator.MoveNext();
            }
        }

        private void SwitchState()
        {
            EnumerateCycle(_enumeratorStates);//false
            EnumerateCycle(_enumeratorPoints); //true
        }

        private void initializeBehavior(Widget widget)
        {
            _enumeratorPoints = _points.GetEnumerator();
            _enumeratorStates = _states.GetEnumerator();

            _enumeratorPoints.MoveNext();
            _enumeratorPoints.MoveNext();

            _enumeratorStates.MoveNext();

            widget.X = _points.First().X;
            widget.Y = _points.First().Y;

        }
    }
}
