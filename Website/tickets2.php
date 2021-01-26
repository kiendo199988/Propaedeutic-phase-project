
<?php
if (!isset($_SESSION)) {
    session_start();
}
use PHPMailer\PHPMailer\Exception;
use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\SMTP;

require 'php mailer/vendor/autoload.php';

$error = null;
if (isset($_POST['submit'])) {
  $mysqli = new MySQLi('studmysql01.fhict.local', 'dbi413156', 'dbi413156', 'dbi413156');
  $id=$_SESSION['id'];
  $insert = $mysqli->query("UPDATE account SET has_ticket = 1, has_cs=1 WHERE id='$id' ");
  if ($insert){

    $mail = new PHPMailer(true);

    try {
        //Server settings
        $mail->SMTPDebug = SMTP::DEBUG_SERVER; // Enable verbose debug output
        $mail->isSMTP(); // Send using SMTP
        $mail->Host = 'mailrelay.fhict.local'; // Set the SMTP server to send through
        $mail->SMTPAuth = true; // Enable SMTP authentication
        $mail->Username = 'i409411'; // SMTP username
        $mail->Password = '962033207'; // SMTP password
        $mail->SMTPSecure = PHPMailer::ENCRYPTION_STARTTLS; // Enable TLS encryption; `PHPMailer::ENCRYPTION_SMTPS` also accepted
        $mail->Port = 587; // TCP port to connect to
        //Recipients
        $mail->setFrom('i409411@hera.fhict.nl', 'KWF');
        $mail->addAddress($_SESSION['email'], $_SESSION['firstName'] . $_SESSION['lastName']); // Add a recipient
        $mail->addReplyTo('no-reply@kwf.com', 'Information');
        // $body = ' <p> <strong> Hello </strong> <br> Thank you for the purchase </p>';
        $greatings = '<strong>Hello  ' . $_SESSION['lastName'] . ', </strong>';
        //$qrcode = '<img src="https://chart.googleapis.com/chart?chs=300x300&cht=qr&chl='.$_SESSION['id'].'"  title="Link to Google.com" >';
        // Content
        $mail->isHTML(true); // Set email format to HTML
        $mail->Subject = 'Thank you for your purchase';
        $mail->Body = $greatings . '
        <p>
        Thank you for the purchase. The following is your important information. We advice you to keep
        them safe and secure because it is critical info.
        <table cellspacing="0" style="width: 800px; height: 90px;">
        <tr>
            <th>Log in info</th><td></td>
        </tr>
        <tr>
            <th>E-mail:</th><td>'. $_SESSION['email'].'</td>
        </tr>
        <tr>
            <th>Password:</th><td>'.$_SESSION['pass'].'</td>
        </tr>
        </table>
        Please login to your account to download your ticket.<br><br>
        Kind regards,<br>
        Tech Quest Team <br>';
        $mail->AltBody = ' <p> <strong> Hello </strong> <br> Thank you for the purchase </p>';
        $mail->send();
    } catch (Exception $e) {
        $error = "Email could not be sent. Mailer Error: {$mail->ErrorInfo}";
    }

    header('location:tickets3.php');
  }
  else {
      echo $mysqli->error;
  }
}

?>
<!DOCTYPE html>
<html lang="en">

<head>
    <?php
    include("template/head.php")
    ?>
    <title>Tickets</title>
</head>

<body>

<div class="header">
    <?php
    include("template/menu_pages.php")
    ?>
    <div class="head-line">
    <h1>Book your tickets now ! </h1>
    </div>
</div>
<div class="fes-info">
    <i class="fa fa-calendar" style="font-size:24px"> Event date: 24-26 January 2020</i>
    <i class="fa fa-map-marker" style="font-size:24px"> Event location : Wezuperbrug, Molecaten Park Kuierpad</i>
</div>

<div class="tickets-container">
    <div class="step1-title">
        <h2 style="font-size:24px; color:#666633;">Step 2: Overview</h2>
        <h2 style="font-size:24px; color:#666633;">You will receive your E-Ticket(s) by email Or you can download them after the payment.</h2>
        <br>
        <h2>My order:</h2>
    </div>
    <br>
    <div class="container">
  <table class="table">
  <thead>
      <tr>
        <th style="text-align:center; font-size:20px;">Products</th>
        <th style="text-align:center; font-size:20px;">Quantity</th>
        <th style="text-align:center; font-size:20px;">Price</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td style="text-align:center;">Regular ticket</td>
        <td style="text-align:center;">1</td>
        <td style="text-align:center;">€ 55.00 EUR</td>
      </tr>
      <tr>
        <td style="text-align:center;">Camping spots</td>
        <td style="text-align:center;">1</td>
        <td style="text-align:center;">€ 30.00 EUR</td>
      </tr>
      <tr>
        <td></td>
        <td></td>
        <td style="text-align:center;">Incl 21% btw € 17.00 EUR</td>
      </tr>
      <tr>
        <td></td>
        <td></td>
        <td style="text-align:center; ">Total: € 85.00 EUR</td>
      </tr>

    </tbody>
  </table>
</div>

<br>
  <form class="register" action="" method="post">
    <div class="next-prev">
        <a type="btn" href="tickets1.php" class="btn-prev">previous</a>
        <button class="pay" type="submit" name="submit"  required>Pay</button>
    </div>
  </form>
</div>


<?php
include("template/footer.php")
?>
</body>
