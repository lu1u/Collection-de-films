using Collection_de_films.Internet;
using System;

using System.Drawing;

using HtmlAgilityPack;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Web;

namespace XPath_Editor
{
    public partial class Form1 : Form
    {
        public const string FILE_HEADER = "CommandLine Front End - L.Pilloni";
        public const string FILE_VERSION = "Version 0.2";
        public const string ERROR_PREFIX = "[lpi.cmdlinefrontend.prefix.error]";
        public const string MESSAGE_PREFIX = "[lpi.cmdlinefrontend.prefix.message]";

        string _xpath = "";
        HtmlAgilityPack.HtmlDocument _doc;
        public Form1()
        {
            InitializeComponent();
        }




        #region console
        // Thread-safe method of appending text to the console box
        delegate void AppendTextDelegate(string text);
        private void AppendConsoleText(string text)
        {
            // Use a delegate if called from a different thread,
            // else just append the text directly
            if (this.consoleRichTextBox.InvokeRequired)
            {
                consoleRichTextBox.Invoke(new AppendTextDelegate(this.AppendConsoleText), new object[] { text });
            }
            else
            {
                try
                {

                    if (text.StartsWith(ERROR_PREFIX))
                    {
                        consoleRichTextBox.SelectionStart = consoleRichTextBox.TextLength;
                        consoleRichTextBox.SelectionLength = 0;

                        consoleRichTextBox.SelectionColor = Color.Coral;
                        consoleRichTextBox.AppendText(text.Substring(ERROR_PREFIX.Length));
                        consoleRichTextBox.SelectionColor = consoleRichTextBox.ForeColor;
                    }
                    else
                        if (text.StartsWith(MESSAGE_PREFIX))
                    {
                        consoleRichTextBox.SelectionStart = consoleRichTextBox.TextLength;
                        consoleRichTextBox.SelectionLength = 0;

                        consoleRichTextBox.SelectionColor = Color.LightGreen;
                        consoleRichTextBox.AppendText(text.Substring(MESSAGE_PREFIX.Length));
                        consoleRichTextBox.SelectionColor = consoleRichTextBox.ForeColor;
                    }
                    else
                        this.consoleRichTextBox.AppendText(text);

                    this.ScrollConsoleToCaret();

                }
                catch (Exception e)
                {
                    this.consoleRichTextBox.Clear();
                    this.AppendConsoleText(ERROR_PREFIX + e.Message);
                    this.AppendConsoleText(text);
                }

            }
        }

        // Thread-safe method of appending text to the console box
        delegate void ScrollToCaretDelegate();
        private void ScrollConsoleToCaret()
        {
            // Use a delegate if called from a different thread,
            // else just append the text directly
            if (this.consoleRichTextBox.InvokeRequired)
            {
                // Application crashes when this line is executed
                consoleRichTextBox.Invoke(new ScrollToCaretDelegate(this.ScrollConsoleToCaret), null);
            }
            else
            {
                consoleRichTextBox?.ScrollToCaret();
            }
        }
        /// <summary>
        /// Ecrit une ligne sur la console et scrolle pour qu'elle soit visible
        /// </summary>
        /// <param name="text"></param>
        public void WriteToConsole(string text)
        {
            AppendConsoleText(text + Environment.NewLine);
        }

        /// <summary>
        /// Ecrit une erreur sur la console
        /// </summary>
        /// <param name="text"></param>
        public void WriteErrorToConsole(string text)
        {
            WriteToConsole(ERROR_PREFIX + text);
        }


        /// <summary>
        /// Afficher une exception dans la console
        /// </summary>
        /// <param name="e"></param>
        public void WriteExceptionToConsole(Exception e)
        {
            WriteErrorToConsole("!Exception raised: " + e.Message);
            WriteErrorToConsole(e.StackTrace);
        }

        /// <summary>
        /// Ecrit un message sur la console
        /// </summary>
        /// <param name="text"></param>
        public void WriteMessageToConsole(string text)
        {
            WriteToConsole(MESSAGE_PREFIX + text);
        }
        #endregion
        private void onClickChargerPageRecherche(object sender, EventArgs e)
        {
            using (new CursorChanger(Cursors.WaitCursor))
            {
                webBrowser.ScriptErrorsSuppressed = true;
                string url = textBoxURLRecherche.Text;
                WriteMessageToConsole("Chargement de la page de recherche " + url);
                webBrowser.Navigate(url);
                _doc = Internet.getInstance().loadPage(url);
                if (_doc == null)
                {
                    WriteMessageToConsole("Erreur de chargement de la page");
                }

                WriteMessageToConsole("Page chargee");
                remplitArbre(treeViewRecherche, _doc.DocumentNode, url);
            }
        }

        private void remplitArbre(TreeView treeView, HtmlNode node, string titre)
        {
            treeView.Nodes.Clear();
            TreeNode n = new TreeNode(titre);
            n.Nodes.Add(new TreeNode("[innerhtml]" + node.InnerHtml));
            n.Nodes.Add(new TreeNode("[innnertext]" + node.InnerText));
            treeView.Nodes.Add(n);
            remplitTreeRecherche(treeView, _doc.DocumentNode, n);

            n.Expand();
        }

        private void remplitTreeRecherche(TreeView treeView, HtmlNode documentNode, TreeNode topNode)
        {
            topNode.Nodes.Add(new TreeNode("[innerhtml]" + documentNode.InnerHtml));
            topNode.Nodes.Add(new TreeNode("[innertext]" + documentNode.InnerText));
            string name;
            if (finiParAttribut(_xpath, out name))
            {
                HtmlAttribute at = documentNode.Attributes[name];
                if (at != null)
                    topNode.Nodes.Add(new TreeNode("[attribut]" + at.Name + "=" + at.Value));

            }
            HtmlAttributeCollection att = documentNode.Attributes;
            if (att != null)
                foreach (HtmlAttribute a in att)
                    topNode.Nodes.Add(new TreeNode("Attribut " + a.Name + "=" + a.Value + ", [xpath=" + a.XPath));

            HtmlNodeCollection nodes = documentNode.SelectNodes("./*");
            if (nodes != null)
            {
                foreach (HtmlNode element in nodes)
                {
                    TreeNode tn = new TreeNode("<" + element.Name + "> " + ", [xpath=" + element.XPath);
                    tn.ForeColor = couleurNoeud(element.Name);

                    /*if (element.InnerText.Contains(_titre))
                    {
                        TreeNode t = tn;
                        tn.BackColor = Color.LightYellow;
                        while (t != null)
                        {
                            t.Expand();
                            t = t.Parent;
                        }
                    }*/
                    remplitTreeRecherche(treeView, element, tn);

                    topNode.Nodes.Add(tn);
                }
            }
        }

        private bool finiParAttribut(string path, out string name)
        {
            name = "";
            int indexArrobas = path.LastIndexOf('@');
            if (indexArrobas == -1)
                return false;

            int indexSlash = path.LastIndexOf('/');

            if (indexSlash > indexArrobas)
                return false;

            name = path.Substring(indexArrobas + 1);
            return true;
        }

        private Color couleurNoeud(string name)
        {
            switch (name)
            {
                case "div":
                    return Color.Blue;
                case "img":
                    return Color.Red;
                case "table":
                    return Color.Green;
                case "a":
                    return Color.Red;
                default:
                    return Color.Black;
            }
        }

        private void treeViewRecherche_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void ontreeviewRechercheNodeDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode n = treeViewRecherche.SelectedNode;
            if (n == null)
                return;

            string text = n.Text;
            int indice = text.IndexOf("[xpath=");
            if (indice != -1)
                textBoxXPathRecherche.Text = text.Substring(indice + 7);
        }

        private List<string> extract(string requete, string xpath)
        {
            WriteMessageToConsole("Requete " + requete);
            HtmlAgilityPack.HtmlDocument doc = Internet.getInstance().loadPage(requete);
            if (doc == null)
            {
                WriteErrorToConsole("Erreur de chargement de la page " + requete);
                return null;
            }
            return extract(doc, xpath);
        }

        private List<string> extract(HtmlAgilityPack.HtmlDocument doc, string xpath)
        {
            if (xpath == null || xpath.Length == 0)
                return null;
            try
            {
                List<string> result = new List<string>();
                HtmlNodeCollection elements = doc.DocumentNode.SelectNodes(xpath);
                if (elements != null)
                {
                    string name;
                    if (finiParAttribut(xpath, out name))
                    {
                        foreach (HtmlNode element in elements)
                        {
                            HtmlAttribute att = element.Attributes[name];
                            if (att != null)
                                result.Add(trim(att.Value));
                        }
                    }
                    else
                    {
                        foreach (HtmlNode element in elements)
                            result.Add(trim(element.InnerHtml));
                    }
                }

                return result;
            }
            catch (Exception)
            {

                return null;
            }
        }
        private string cumuleExtract(HtmlAgilityPack.HtmlDocument doc, string xpath)
        {
            List<string> elements = extract(doc, xpath);
            if (elements == null)
                return "";


            switch (elements.Count)
            {
                case 0:
                    return "";

                case 1:
                    return elements[0];

                default:
                    string result = elements[0];
                    for (int i = 1; i < elements.Count; i++)
                        result += ", " + elements[i];

                    return result;
            }
        }
        public static readonly char[] TRIM_CHAR = { ' ', ',', '\n' };

        public static string trim(string key)
        {

            if (key == null)
                return "";
            return HttpUtility.HtmlDecode(key).Trim().Trim(TRIM_CHAR);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (_doc == null)
                return;
            _xpath = textBoxXPathRecherche.Text;
            try
            {
                HtmlNodeCollection nodes = _doc.DocumentNode.SelectNodes(_xpath);
                if (nodes == null)
                {
                    WriteErrorToConsole("Impossible de charger le node " + _xpath);
                }

                treeViewXPath.Nodes.Clear();
                TreeNode root = new TreeNode(_xpath);
                TreeNode extract = new TreeNode("[Extract:] " + cumuleExtract(_doc, _xpath));
                extract.ForeColor = Color.CadetBlue;
                root.Nodes.Add(extract);
                treeViewXPath.Nodes.Add(root);
                foreach (HtmlNode n in nodes)
                {
                    remplitTreeRecherche(treeViewXPath, n, root);
                }

                root.Expand();
            }
            catch (Exception ex)
            {
                WriteExceptionToConsole(ex);
            }
        }
    }
}

