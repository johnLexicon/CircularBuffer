using System;

namespace CircularBuffer
{

    /// <summary>
    /// First in First out FIFO algorithm.
    /// </summary>
    public class CircularBuffer
    {
        private readonly int[] _content;

        //Index for the data that is going to be retrieved.
        private int _tail = 0;
        //Index for the data that is going to be added.
        private int _head = 0;
        //Count of existing elements in the data.
        private int _count = 0;

        public CircularBuffer(int maxSize)
        {
            _content = new int[maxSize];
        }

        private void OverWriteData()
        {

        }

        public int AddValue(int value)
        {
            _head = _head % this._content.Length;
            _content[_head] = value;
            if(_count == _content.Length)
            {
                _tail++;
            }
            else
            {
                _count++;
            }
            _head++;
            return _head;
        }

        public int RetrieveValue()
        {
            if(_count == 0)
            {
                throw new Exception("No value available in buffer");
            }

            int value = _content[_tail];
            _tail++;
            _count--;
            return value;
        }

        public int[] GetBufferContent()
        {
            int[] temp = new int[_content.Length];
            Array.Copy(_content, temp, this._content.Length);
            return temp;
        }
    }
}
