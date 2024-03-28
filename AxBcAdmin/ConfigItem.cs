namespace AxBcAdmin
{

    /// <summary>
    /// Represents a setting in the <c>CustomSettings.config</c> file
    /// </summary>
    internal class ConfigItem
    {
        string fValue;

        /* construction */
        /// <summary>
        /// Constructor.
        /// </summary>
        public ConfigItem(XmlElement Element, XmlComment Comment)
        {
            Category = "Miscs";

            string ValidOptions = "Valid options: ";
            if (Element != null && Element.Attributes.Count >= 2)
            {
                Key = Element.Attributes[0].Value;
                fValue = Element.Attributes[1].Value;


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

            ConfigItemInfo ItemInfo = ConfigItemInfo.List.FirstOrDefault(item => item.Key.Equals(this.Key, StringComparison.InvariantCultureIgnoreCase));
            this.Category = ItemInfo != null ? ItemInfo.Category : "Miscs"; 
 
        }

        /* public */
        /// <summary>
        /// Override. Returns a string representation of this instance.
        /// </summary>
        public override string ToString()
        {
            return !string.IsNullOrWhiteSpace(Key) ? Key : base.ToString();
        }

        /* properties */
        /// <summary>
        /// Item Category
        /// </summary>
        public string Category { get; }
        /// <summary>
        /// Name, e.g. <c>Instance Name</c>
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Key, e.g. <c>InstanceName</c>
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Value, e.g. <c>BC230</c>
        /// </summary>
        public string Value
        {
            get { return fValue; }
            set
            {
                if (value != fValue)
                {
                    fValue = value;
                    IsChanged = true;
                }
            }
        }
        /// <summary>
        /// The XML comment preceding the setting entry.
        /// </summary>
        public string CommentText { get; }
        /// <summary>
        /// A list of possible values for the setting entry
        /// </summary>
        public List<string> Options { get; } = new List<string>();
        /// <summary>
        /// True when its Options is not an empty list
        /// </summary>
        public bool HasOptions { get { return Options.Count > 0; } }
        /// <summary>
        /// True when the Value of this instance changes.
        /// </summary>
        public bool IsChanged { get; private set; }
    }
}
