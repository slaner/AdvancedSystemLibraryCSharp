using System;
using System.Text;

namespace TeamDEV.Asl.Utilities {
    /// <summary>
    /// Indentable text buffer
    /// </summary>
    internal class TraceBuffer {
        private const int DefaultIndentSize = 4;
        private const char DefaultIndentChar = ' ';
        private const string DefaultIndentString = "    ";

        private StringBuilder mText = new StringBuilder();
        private int mIndentLevel = 0;
        private int mIndentSize = DefaultIndentSize;
        private char mIndentChar = DefaultIndentChar;
        private string mIndentCache = DefaultIndentString;
        private bool mCacheEmpty = true;

        public void Append(byte value) {
            Append(value.ToString());
        }
        public void Append(sbyte value) {
            Append(value.ToString());
        }
        public void Append(short value) {
            Append(value.ToString());
        }
        public void Append(ushort value) {
            Append(value.ToString());
        }
        public void Append(int value) {
            Append(value.ToString());
        }
        public void Append(uint value) {
            Append(value.ToString());
        }
        public void Append(long value) {
            Append(value.ToString());
        }
        public void Append(ulong value) {
            Append(value.ToString());
        }
        public void Append(float value) {
            Append(value.ToString());
        }
        public void Append(double value) {
            Append(value.ToString());
        }
        public void Append(decimal value) {
            Append(value.ToString());
        }
        public void Append(char value) {
            Append(value.ToString());
        }
        public void Append(object value) {
            Append(value.ToString());
        }
        public void Append(string value) {
            Append(value, false);
        }
        public void Append(string value, bool indent = false) {
            if (mCacheEmpty || !indent) mText.Append(value);
            else mText.Append(mIndentCache + value);
        }
        public void AppendLine() {
            Append(Environment.NewLine);
        }
        public void AppendLine(byte value) {
            AppendLine(value.ToString());
        }
        public void AppendLine(sbyte value) {
            AppendLine(value.ToString());
        }
        public void AppendLine(short value) {
            AppendLine(value.ToString());
        }
        public void AppendLine(ushort value) {
            AppendLine(value.ToString());
        }
        public void AppendLine(int value) {
            AppendLine(value.ToString());
        }
        public void AppendLine(uint value) {
            AppendLine(value.ToString());
        }
        public void AppendLine(long value) {
            AppendLine(value.ToString());
        }
        public void AppendLine(ulong value) {
            AppendLine(value.ToString());
        }
        public void AppendLine(float value) {
            AppendLine(value.ToString());
        }
        public void AppendLine(double value) {
            AppendLine(value.ToString());
        }
        public void AppendLine(decimal value) {
            AppendLine(value.ToString());
        }
        public void AppendLine(char value) {
            AppendLine(value.ToString());
        }
        public void AppendLine(object value) {
            AppendLine(value.ToString());
        }
        public void AppendLine(string value) {
            AppendLine(value, true);
        }
        public void AppendLine(string value, bool indent = true) {
            Append(value + Environment.NewLine, indent);
        }
        public void AppendLineNoIndent() {
            Append(Environment.NewLine);
        }
        
        /// <summary>
        /// Increase indent level by 1
        /// </summary>
        public void Indent() {
            if (mIndentLevel < int.MaxValue) {
                mIndentLevel++;
                UpdateIndentCache();
            }
        }
        /// <summary>
        /// Decrease indent level by 1
        /// </summary>
        public void Unindent() {
            if (mIndentLevel > 0) {
                mIndentLevel--;
                UpdateIndentCache();
            }
        }
        /// <summary>
        /// Clear buffer and reset indent information
        /// </summary>
        public void Clear() {
            mText.Clear();
            ResetIndent();
        }
        /// <summary>
        /// Reset indent information
        /// </summary>
        public void ResetIndent() {
            mIndentSize = DefaultIndentSize;
            mIndentChar = DefaultIndentChar;
            mIndentCache = DefaultIndentString;
            mIndentLevel = 0;
            UpdateIndentCache();
        }

        /// <summary>
        /// Determine indent character
        /// </summary>
        public char IndentChar {
            get => mIndentChar;
            set {
                if (mIndentChar != value) {
                    mIndentChar = value;
                    UpdateIndentCache();
                }
            }
        }
        /// <summary>
        /// Determine indent size
        /// </summary>
        public int IndentSize {
            get => mIndentSize;
            set {
                if (mIndentSize != value) {
                    mIndentSize = value;
                    UpdateIndentCache();
                }
            }
        }

        public override string ToString() {
            return mText.ToString();
        }

        private void UpdateIndentCache() {
            mIndentCache = null;
            if (mIndentLevel > 0)
                mIndentCache = new string(mIndentChar, mIndentSize * mIndentLevel);

            mCacheEmpty = mIndentCache == null;
        }
    }
}