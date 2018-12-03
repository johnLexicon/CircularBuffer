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

        /// <summary>
        /// Adds a value to the buffer. If the buffer is full then it overwrites the oldest value in the buffer. And lets the tail point to the next value.
        /// </summary>
        /// <param name="value">The value to insert into the buffer</param>
        /// <returns>The count of elements in the buffer</returns>
        public int AddValue(int value)
        {
            _head = _head % this._content.Length;
            _content[_head] = value;

            //If the buffer is full move the tail to the next element in the buffer, otherwise increment the count of added elements.
            if(_count == _content.Length)
            {
                _tail++;
            }
            else
            {
                _count++;
            }
            _head++;

            return _count;
        }

        /// <summary>
        /// Retrieves the first inserted value in the buffer. Then moves the tail to point to the next element if one exists.
        /// </summary>
        /// <returns>The first inserted value in the buffer</returns>
        /// Throws an Exception if there are no value to retrieve.
        public int RetrieveValue()
        {
            if(_count == 0)
            {
                throw new Exception("No value available in buffer");
            }

            _tail = _tail % _content.Length;
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
