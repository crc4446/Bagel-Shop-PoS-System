using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MIS316_MP2B : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnStart_Click(object sender, EventArgs e)
    {
        // Show Order Selections panel and hide all others
        /***** WRITE 1 LINE OF CODE THAT USES THE METHOD NAMED ShowPanel HERE *****/
        // displayes the order selection panel
        ShowPanel(2);


        // call method to summarize the initial input
        SummarizeInput(); /***** DO NOT CHANGE EXCEPT TO REMOVE THE COMMENTS AFTER YOU'VE WRITTEN THIS METHOD *****/
    }

    protected void btnFinish_Click(object sender, EventArgs e)
    {
        // show Receipt panel and hide all others
        /***** WRITE 1 LINE OF CODE THAT USES THE METHOD NAMED ShowPanel HERE *****/
        // displayes the receipt panel
        ShowPanel(3);


        // declare variables to be used and give defaults
        int intNumberOfBagels = 0; /***** DO NOT CHANGE *****/
        decimal decTaxRate = 0m; /***** DO NOT CHANGE *****/
        decimal decSubtotal = 0m; /***** DO NOT CHANGE *****/
        decimal decTax = 0m; /***** DO NOT CHANGE *****/
        decimal decTotal = 0m; /***** DO NOT CHANGE *****/

        // grab and convert input for number of bagels and tax rate
        /***** WRITE 2 LINES OF CODE THAT READ THE INPUT FROM THE USER AND STORE IT IN intNumberOfBagels and decTaxRate *****/
        intNumberOfBagels = Convert.ToInt32(txtNumberOfBagels.Text);
        decTaxRate = Convert.ToDecimal(rblOrderType.SelectedValue);

        // calculate subtotal, tax, and total
        /***** WRITE THE LINES OF CODE THAT CALL THE GetBagelCost, GetCostOfOptions and CalculateTax METHODS THAT YOU CREATED *****/
        decSubtotal = (GetBagelCost() + GetCostOfOptions()) * intNumberOfBagels;
        decTax = CalculateTax(decSubtotal, decTaxRate);
        decTotal = decSubtotal + decTax;









        // get a summary of the options selected
        /***** WRITE THE LINE OF CODE THAT CALLS THE GetSelectedOptions METHOD THAT YOU CREATED AND STORES IT IN A NEW STRING VARIABLE *****/
        string strSelectedOptions = ""; 
        strSelectedOptions = GetSelectedOptions();



        // output the receipt details
        /***** WRITE 1 LINE OF CODE THAT CALLS THE GenerateReceipt METHOD THAT YOU CREATED AND STORES IT IN lblOrderSummary's TEXT PROPERTY *****/
        lblOrderSummary.Text = GenerateReceipt(txtCustomerName.Text, intNumberOfBagels, ddlTypeOfBagel.SelectedItem.Text, strSelectedOptions, rblPaymentType.SelectedItem.Text, decSubtotal, decTax, decTotal);

    }

    protected void btnNextCustomer_Click(object sender, EventArgs e)
    {
        ResetAllSettings(); /***** DO NOT CHANGE EXCEPT TO REMOVE THE COMMENTS AFTER YOU'VE WRITTEN THIS METHOD *****/
    }

    protected void ShowPanel(int intPanelNumber) /***** DO NOT CHANGE ANYTHING IN THIS METHOD *****/
    {
        /* This method hides all panels except the one designated by the parameter
            * 1 = Start panel
            * 2 = Order Selections panel
            * 3 = Receipt panel
            * 
            */

        // hide all panels
        pnlStart.Visible = false;
        pnlOrderSelections.Visible = false;
        pnlReceipt.Visible = false;

        // show one panel based on parameter
        if (intPanelNumber == 1)
        {
            pnlStart.Visible = true;
        }
        else if (intPanelNumber == 2)
        {
            pnlOrderSelections.Visible = true;
        }
        else
        {
            pnlReceipt.Visible = true;
        }
    }


    /* METHOD #1: SummarizeInput
     * It should:
     *      have no return
     *      have no parameters
     *      take the input from the 2 TextBoxes and place them in the 2 corresponding Labels
     *      set the Text property of lblOrderType based on the selection in the Order Type RadioButtonList
     *      set the Text property of lblTaxRate based on the selection in the Order Type RadioButtonList
     *          
     *      >>> HINT: decimal variables can be formatted as percentages with 2 decimal places by using .ToString("P")
     *          
     */
    protected void SummarizeInput()
    {
        // store user input as the text property of the labels
        lblCustomerName.Text = txtCustomerName.Text;
        lblNumberOfBagels.Text = txtNumberOfBagels.Text;

        // store the users order type selection in the text property of the ordertypelabel
        lblOrderType.Text = rblOrderType.SelectedItem.Text;
        // depending on the user selection, the tax rate will be stored in the text property of the tax rate label
        lblTaxRate.Text = Convert.ToDecimal(rblOrderType.SelectedValue).ToString("P");
    }



    /* METHOD #2: GetSelectedOptions
     * It should:
     *      return a string that lists the additional options the user selected (separated by commas)
     *           for example: Cream Cheese, Toasted, Peanut Butter
     *      have no parameters
     *      the logic for this method should loop through all ListItem objects in the cblAdditionalOptions CheckBoxList and
     *           append each option's name if it's selected
     *           
     *      >>> HINT: You can append a comma before all of the options EXCEPT the first one. To determine which one is
     *          the first one, you can use a counter OR a flag.
     *               
     */
    protected string GetSelectedOptions()
    {
        // declare variables for our method and the return
        string strAddOptions = "";
        string strAddOptionsReturn = "";
        int intCounter = 0;

        // look through each list item in the checkboxlist and see if the user checked that list item 
        foreach (ListItem liOption in cblAdditionalOptions.Items)
        {
            // each checked list item will add 1 to our counter, and append the text property of the list item to our return variable
            if (liOption.Selected == true)
            {
                intCounter += 1;
                // check to see if more than one checkbox list item was selected by the user and append a comma
                if (liOption.Selected == true && intCounter > 1)
                {
                    strAddOptionsReturn += ", ";
                }
                strAddOptions = liOption.Text;
                strAddOptionsReturn += strAddOptions;


            }
        }
        // check if no additional options were checked and output None for the return variable
        if (intCounter == 0)
        {
            strAddOptionsReturn = "None";
        }
                    
        return strAddOptionsReturn;
    }


    /* METHOD #3: GetBagelCost
     * It should:
     *      return a decimal that is the cost of the selected bagel type
     *      have no parameters
     *      
     *      >>> HINT: Make sure to familiarize yourself with the DropDownList item settings. The price is in the Value property
     *          of each ListItem.
     *      
     */
    protected decimal GetBagelCost()
    {
        /* declare the return variable
        /  the value property of the bagel selected is stored in the return variable
        */
        decimal decBagelCost = Convert.ToDecimal(ddlTypeOfBagel.SelectedValue);

        return decBagelCost;
    }


    
    /* METHOD #4: GetCostOfOptions
     * It should:
     *      return a decimal that is the sum of all of the costs of the selected additional options
     *      have no parameters
     *      the logic for this method should loop through all ListItem objects in the cblAdditionalOptions CheckBoxList
     *      
     *      >>> HINT: This uses a running total.
     * 
     */
    protected decimal GetCostOfOptions()
    {
        // declare variable holding the running total
        decimal runningTotal = 0.00m;

        // look through each user selected list item's value property and add it to the running total
        foreach (ListItem liOption in cblAdditionalOptions.Items)
        {
            if (liOption.Selected == true)
            {
                runningTotal += Convert.ToDecimal(liOption.Value);
            }
        }
        return runningTotal;
    }    


    /* METHOD #5: CalculateTax
     * It should:
     *      return a decimal that is the product of a subtotal and tax rate
     *      has 2 parameters: a subtotal and a tax rate
     *      
     *      >>> HINT: Don't forget to use appropriate data types for your parameters.
     * 
     */
    protected decimal CalculateTax(decimal decSubtotal, decimal decTaxRate)
    {
        // declare the return variable holding the calculated tax rate
        decimal decCalcTax = 0.00m;

        // if the user selects dine in, the value property of dine in will be place in the tax rate variable
        if (rblOrderType.SelectedIndex == 1)
        {
            decTaxRate = Convert.ToDecimal(rblOrderType.SelectedValue);
            decCalcTax = decTaxRate * decSubtotal;
        }
        // if the user selects carry out, no tax fee is applied
        else
        {
            decCalcTax = 0.00m;
        }
        return decCalcTax;
    }


    /* METHOD #6: GenerateReceipt
     * It should:
     *      return a string that summarizes the order in this format:
     *           Order for [Name]
     *           
     *           [#] [BagelType] bagel[s]
     *           Added Options: [List of options]
     *           
     *           Paying by [PaymentType]
     *           
     *           Subtotal: $[0.00] ($[0.00] each)
     *           Tax: $[0.00]
     *           Total: $[0.00]
     *      has 8 parameters: name, number of bagels, bagel type, options list, payment type, subtotal, tax, and total
     *      
     *      >>> NOTE: The parts in [square brakcets] above will change depending on the input.
     *                Don't forget the line breaks <br /> in the receipt string.
     *                
     *      >>> HINT: This will be a lot of string concatenation. This method will build one large string that gets returned.
     *      >>> HINT: Don't forget the logic for the s on bagel(s). You also need to do math to determine the "price each" for the bagels. 
     * 
     */
    protected string GenerateReceipt(string strName, int intNumOfBagels, string strBagelType, string strOptList, string strPaymentType, decimal decSubtotal, decimal decTax, decimal decTotal)
    {
        // declare variables that store the price per bagel, and receipt summary
        string summarizeReceipt = "";
        decimal decPriceEach = decSubtotal / intNumOfBagels;

        // check to see if more than 1 bagel was submitted by the user and append an "s" on the string
        if (intNumOfBagels > 1)
        {
            summarizeReceipt = "Order for " + strName + "<br />" + "<br />" + intNumOfBagels + " " + strBagelType + " bagels" + "<br />" + "Added Options: " + strOptList + "<br />" + "<br />" + "Paying by " + strPaymentType + "<br />" + "<br />" + "Subtotal: " + decSubtotal.ToString("C") + " (" + decPriceEach.ToString("C") + " each" + ")" + "<br />" + "Tax: " + decTax.ToString("C") + "<br />" + "Total: " + "<strong>" + decTotal.ToString("C") + "</strong>";

        }
        else
        {
            summarizeReceipt = "Order for " + strName + "<br />" + "<br />" + intNumOfBagels + " " + strBagelType + " bagel" + "<br />" + "Added Options: " + strOptList + "<br />" + "<br />" + "Paying by " + strPaymentType + "<br />" + "<br />" + "Subtotal: " + decSubtotal.ToString("C") + " (" + decPriceEach.ToString("C") + " each" + ")" + "<br />" + "Tax: " + decTax.ToString("C") + "<br />" + "Total: " + "<strong>" + decTotal.ToString("C") + "</strong>";

        }

        return summarizeReceipt;
    }


    /* METHOD #7: ResetAllSettings
     * It should:
     *      have no return
     *      have no parameters
     *      use the ShowPanel method above to hide all except the Start panel
     *      change all options back to the starting state, this includes:
     *           the 2 TextBoxes
     *           the 5 summary Labels (4 in the 2nd panel and 1 in the 3rd panel)
     *           the 2 RadioButtonLists
     *           the 1 DropDownList
     *           looping through to uncheck all of the Items in the CheckBoxList
     *           
     *      >>> HINT: Remember that you can reference the indexes of Lists
     * 
     */
    protected void ResetAllSettings()
    {
        // display the start panel
        ShowPanel(1);

        // clear out text boxes
        txtCustomerName.Text = "";
        txtNumberOfBagels.Text = "";

        // clear out labels
        lblCustomerName.Text = "";
        lblNumberOfBagels.Text = "";
        lblOrderSummary.Text = "";
        lblOrderType.Text = "";
        lblTaxRate.Text = "";

        // clear the radiobuttonlists
        rblOrderType.SelectedIndex = 0;
        rblPaymentType.SelectedIndex = 0;
        cblAdditionalOptions.ClearSelection();

        // clear the dropdownlist
        ddlTypeOfBagel.SelectedIndex = 0;
    }

}