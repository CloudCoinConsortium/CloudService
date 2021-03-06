﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Exchange.aspx.cs" Inherits="CloudService.Exchange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .grandTotal {
	        text-align: center;
	        horizontal-align: center;
        }
        table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
	        background-color: black;
            padding: 8px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }

        tr:hover {background-color:#8e8e8e;}

        #cta select option {
            color: black;
            background-color: white;
        }

        select option {
            color: #111;
            background-color: #000;
        }
	</style>
    <link href="main.css" rel="stylesheet" />
    <script src="https://use.fontawesome.com/b7a745f5ac.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <section id="banner">
            <div class="inner">
                <h1>CloudCoin Exchange</h1>
                <p>The future of digital currency.</p>
                <br />
                <asp:Label runat="server" ID="LBLCurrentPrice"></asp:Label>
            </div>
            <video autoplay="" loop="" muted="" playsinline="" src="images/banner.mp4"></video>
        </section>
        <section class="wrapper" id="cta">
            <div class="inner">
            <table>
                <tbody>
                    <tr style="padding: 10px 10px 10px 10px;">
                        <th>CloudCoin</th>
                        <th>Denomination</th>
                        <th>Amount</th>
                        <th>Stock Available</th>
                    </tr>
                    <tr>
                        <td><img alt="1 CloudCoin" src="http://www.cloudcoin.global/images/cc-1.jpg" width="200" /></td>
                        <th>1s</th>
                        <td><asp:DropDownList ID="DDLOnes" onchange="totals()" runat="server"></asp:DropDownList></td>
                        <td><asp:Label id="LBLOnesAvailable" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><img alt="5 CloudCoin" src="http://www.cloudcoin.global/images/cc-5.png" width="200" /></td>
                        <th>5s</th>
                        <td><asp:DropDownList ID="DDLFives" onchange="totals()" runat="server"></asp:DropDownList></td>
                        <td><asp:Label id="LBLFivesAvailable" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><img alt="25 CloudCoin" src="http://www.cloudcoin.global/images/cc-25.png" width="200" /></td>
                        <th>25s</th>
                        <td><asp:DropDownList ID="DDLTwentyFives" onchange="totals()" runat="server"></asp:DropDownList></td>
                        <td><asp:Label id="LBLTwentyFivesAvailable" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><img alt="100 CloudCoin" src="http://www.cloudcoin.global/images/cc-100.png" width="200" /></td>
                        <th>100s</th>
                        <td><asp:DropDownList ID="DDLHundreds" onchange="totals()" runat="server"></asp:DropDownList></td>
                        <td><asp:Label id="LBLHundredsAvailable" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><img alt="250 CloudCoin" src="http://www.cloudcoin.global/images/cc-250.png" width="200" /></td>
                        <th>250s</th>
                        <td><asp:DropDownList ID="DDLTwoHundredFifties" onchange="totals()" runat="server"></asp:DropDownList></td>
                        <td><asp:Label id="LBLTwoHundredFiftiesAvailable" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <th colspan="4"><b colspan="4">Grand Total: <asp:label id="grandtotal" runat="server"></asp:label></b> &nbsp; &nbsp;
                        <table border="0" cellpadding="0" cellspacing="2">
                            <tbody>
                                <tr>

                                    <td>
                                        <asp:Button runat="server" ID="BTNSubmitGreenPay" style="background-image: url(images/PayNowButton.png); width: 157px; height: 55px;" OnClick="BTNSubmitGreenPay_Click"/>
                                        
                                    </td>
                                    <!--<td align="center"><input name="GreenButton_id" type="hidden" value="11389" /><input name="TransactionID" type="hidden" value="" /><input id="BTNSubmit" runat="server" alt="" border="0" name="submit" src="https://greenbyphone.com/eCheck/images/PayNowButton.png" type="image" /><img alt="" border="0" height="1" src="https://greenbyphone.com/eCheck/images/spacer.gif" width="1" /></td>
                                    -->
                                </tr>
                                <tr>
                                    <asp:Label runat="server" id="LBLWarning" Text="Order must be at least $5.00 to process!"></asp:Label>
                                </tr>
                            </tbody>
                        </table>
                        </th>
                    </tr>
                </tbody>
            </table>
        </div>
    </section>
    <footer id="footer">
        <div class="inner">
            <div class="content">
                <section>
                    <h3>Extra Info</h3>
                    <p>Secure Email Based in Switzerland. <a href="https://protonmail.com/" style="color:white;">Get Protonmail</a><br />
                    Help Desk Available between 8am and 5pm PST.<br />
                </section>
                <section>
                    <h4>Contact Us</h4>
                    <ul class="alt">
                    <li><a href="mailto:CloudCoin.HelpDesk@protonmail.com" style="color:white;"><u><span class="__cf_email__" >CloudCoin.HelpDesk@protonmail.com</span></u></a><br />
                        <a href="tel:1-530-500-2646"><u>1-530-500-2646</u></a></li>
                    <li>To verify this website is a trusted seller of CloudCoin, contact the Help Desk</li>
                    </ul>
                </section>
                <section>
                <h4>Social Media</h4>
                    <ul class="plain">
                    <li><a href="https://twitter.com/CloudCoinGlobal"><i class="fa-twitter fa">&nbsp;</i>Twitter</a></li>
                    <li><a href="https://www.facebook.com/cloudcoinconsortium/"><i class="fa-facebook fa">&nbsp;</i>Facebook</a></li>
                    <li><a href="https://github.com/CloudCoinConsortium"><i class="fa fa-github">&nbsp;</i>Git</a></li>
                    </ul>
                </section>
            </div>
            <div class="copyright"><a href="http://cloudcoin.global/">CloudCoin.global</a> &copy; 2018</div>
            </div>
</footer>
        <input id="pricepercoin" type="hidden" runat="server" value="0"/>
    </form>
</body>
    <script type="text/javascript">
        function totals() {
            var totalCoins = 0;
            var totalPrice = 0;
            var pricePerCoin = parseFloat(pricepercoin.value);

            var ones = parseInt(DDLOnes.value);
            var fives = parseInt(DDLFives.value);
            var twentyfives = parseInt(DDLTwentyFives.value);
            var hundreds = parseInt(DDLHundreds.value);
            var twohundredfifties = parseInt(DDLTwoHundredFifties.value);

            totalCoins = ones + fives + twentyfives + hundreds + twohundredfifties;
            totalPrice = totalCoins * pricePerCoin;
            grandtotal.value = totalPrice;
            grandtotal.innerText = "$" + totalPrice.toFixed(2);
            if (totalPrice > 4.99) {
                LBLWarning.innerText = "";
            }
            else
            {
                LBLWarning.innerText = "Order must be at least $5.00 to process!";
            }
        }



    </script>
</html>
