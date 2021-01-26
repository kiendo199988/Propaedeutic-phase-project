<?php
if (!isset($_SESSION)) {
    session_start();
}
$error = null;

require __DIR__.'/vendor/autoload.php';

use Spipu\Html2Pdf\Html2Pdf;

$html2pdf = new Html2Pdf();
$html2pdf->writeHTML

('<head>

<style>
body, html {
  height: 100%;
}
</style>
</head>

<body>
  <h3>Ticket</h3>
  <img src="img/mflogo.png" >
  <h3 class="t">Kuierpad Winter Fest | Wezuperbrug</h3>
<div class="container" >
  <div class="event" style="background-color:whitesmoke;">
    <h4 class="t" > Event date: 24-26 January 2020</h4>
    <h4 class="t" > Event location : Wezuperbrug, Molecaten Park Kuierpad</h4>
  </div>
  <br />
  <br />
  <table class="table">
    <tbody>
      <tr>
        <td style="font-size:20px;">'.$_SESSION['firstName'].'</td>
        <td style="font-size:20px;">'.$_SESSION['lastName'].'</td>
      </tr>
      <tr>
        <td style="font-size:20px;">Email:</td>
        <td style="font-size:20px;">'.$_SESSION['email'].'</td>
      </tr>
    </tbody>
  </table>
</div>
    <div class="t" >
      <img src="https://chart.googleapis.com/chart?chs=300x300&cht=qr&chl='.$_SESSION['id'].'"  title="Link to Google.com" >
    </div>
    <div class="ti">
       <h5>
           Use QR code to check in at the entrance and use your online balance to buy food/ drinks or loan materials
           (USB cable camera charger for your laptop etc.)
           ( it is not possible to pay in cash).
       </h5>
    </div>

</body>'
);
$html2pdf->output();
?>
