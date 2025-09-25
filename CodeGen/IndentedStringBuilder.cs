using System.Text;

namespace SchemaX_CodeGen.CodeGen
{
    public class IndentedStringBuilder
    {
        private readonly StringBuilder _sb = new();
        private int _indentLevel = 0;
        private const string IndentString = "    ";

        public void Indent() => _indentLevel++;
        public void Unindent() => _indentLevel = Math.Max(0, _indentLevel - 1);

        public void AppendLine(string line = "")
        {
            if (!string.IsNullOrEmpty(line))
                _sb.Append(new string(' ', _indentLevel * IndentString.Length));
            _sb.AppendLine(line);
        }

        public void Append(string text)
        {
            _sb.Append(new string(' ', _indentLevel * IndentString.Length));
            _sb.Append(text);
        }

        public override string ToString() => _sb.ToString();
    }
}
