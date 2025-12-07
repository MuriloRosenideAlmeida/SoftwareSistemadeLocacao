using System;
using System.Windows.Forms;

namespace EstruturaFesta.Utils
{
    public static class SistemaUpperCase
    {
        /// <summary>
        /// Aplica maiúsculo automaticamente em todos os componentes suportados:
        /// TextBox, ComboBox, RichTextBox, MaskedTextBox e DataGridView.
        /// </summary>
        public static void AplicarMaiusculo(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                // TextBox normal
                if (ctrl is TextBox tb)
                {
                    tb.CharacterCasing = CharacterCasing.Upper;
                }

            }
        }


    }
}