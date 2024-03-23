using System.Text.RegularExpressions;
using System.Xml;

namespace AxBcAdmin
{
    internal class ConfigItem
    {
        public ConfigItem(XmlElement Element, XmlComment Comment)
        {
            Category = "Miscs";

            string ValidOptions = "Valid options: ";
            if (Element != null && Element.Attributes.Count >= 2)
            {
                Key = Element.Attributes[0].Value;
                Value = Element.Attributes[1].Value;


                // split on capital letters
                var Words = Regex.Matches(Key, @"([A-Z][a-z]+)")
                            .Cast<Match>()
                            .Select(m => m.Value);

                Name = string.Join(" ", Words); 
            }

            if (Comment != null)
            {
                CommentText = Comment.InnerText;
            }

            if (Value == "true" || Value == "false")
            {
                Options.Add("true");
                Options.Add("false");
            }
            else if (CommentText.ContainsText(ValidOptions))
            {
                int Index = CommentText.IndexOf(ValidOptions);
                if (Index != -1)
                {
                    Index += ValidOptions.Length;
                    string Text = CommentText.Substring(Index).Trim();
                    string[] Parts = Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string Part in Parts)
                    {
                        Options.Add(Part);
                    }

                }
            }

            ConfigItemInfo ItemInfo = ConfigItemInfo.List.FirstOrDefault(item => item.Key == this.Key);
            this.Category = ItemInfo != null ? ItemInfo.Category : "Miscs"; 
 
        }

        public override string ToString()
        {
            return !string.IsNullOrWhiteSpace(Key) ? Key : base.ToString();
        }

        public string Category { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string CommentText { get; }
        public List<string> Options { get; } = new List<string>();
        public bool HasOptions { get { return Options.Count > 0; } }
        public bool IsChanged { get; set; }
    }
}
