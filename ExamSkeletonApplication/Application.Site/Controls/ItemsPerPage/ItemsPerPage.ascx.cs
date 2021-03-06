﻿namespace Application.Site.Controls.ItemsPerPage
{
    using System;
    using System.Web.UI.WebControls;

    public partial class ItemsPerPAge : System.Web.UI.UserControl
    {
        public ItemsPerPAge()
        {
            this.StartValue = 5;
            this.OptionsCount = 5;
            this.OptionSize = 5;
        }

        public string ControlId { get; set; }

        public string PagerId { get; set; }

        public int StartValue { get; set; }

        public int OptionSize { get; set; }

        public int OptionsCount { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.RenderSelector();
                DataPager pager = (DataPager)this.Parent.FindControl(this.ControlId).FindControl(this.PagerId);
                pager.PageSize = this.StartValue;
                this.ItemsCountSelect.SelectedValue = this.StartValue.ToString();
            }
        }

        protected void RenderSelector()
        {
            this.ItemsCountSelect.Items.Add(new ListItem(this.StartValue.ToString(), this.StartValue.ToString()));

            for (int i = 1; i < this.OptionsCount; i++)
            {
                var optionValue = (this.StartValue + (this.OptionSize * i)).ToString();
                this.ItemsCountSelect.Items.Add(new ListItem(optionValue, optionValue));
            }
        }

        protected void ChangeItems_PerPage(object sender, EventArgs e)
        {
            DataPager pager = (DataPager)this.Parent.FindControl(this.ControlId).FindControl(this.PagerId);
            pager.PageSize = int.Parse(this.ItemsCountSelect.SelectedValue);
            pager.SetPageProperties(0, pager.PageSize, true);
            pager.Visible = pager.PageSize < pager.TotalRowCount;
        }
    }
}