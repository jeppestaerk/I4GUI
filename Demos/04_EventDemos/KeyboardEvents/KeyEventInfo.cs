using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyboardEvents
{
    public class KeyEventInfo
    {
        public KeyEventInfo(System.Windows.Input.KeyEventArgs e)
        {
            Event = e.RoutedEvent.Name;
            Key = e.Key.ToString();
            SystemKey = e.SystemKey.ToString();
            Ime = e.ImeProcessedKey.ToString();
            KeyStates = e.KeyStates.ToString();
            IsDown = e.IsDown.ToString();
            IsUp = e.IsUp.ToString();
            IsToggled = e.IsToggled.ToString();
            IsRepeat = e.IsRepeat.ToString();
        }

        public KeyEventInfo(System.Windows.Input.TextCompositionEventArgs e)
        {
            Event = e.RoutedEvent.Name;
            Text = e.Text;
            ControlText = e.ControlText;
            SystemText = e.SystemText;
        }

        public string Event { get; set; }
        public string Key { get; set; }
        public string SystemKey { get; set; }
        public string Text { get; set; }
        public string ControlText { get; set; }
        public string SystemText { get; set; }
        public string Ime { get; set; }
        public string KeyStates { get; set; }
        public string IsDown { get; set; }
        public string IsUp { get; set; }
        public string IsToggled { get; set; }
        public string IsRepeat { get; set; }
    }
}
