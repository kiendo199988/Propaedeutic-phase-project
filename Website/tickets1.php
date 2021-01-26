<?php
if (!isset($_SESSION)) {
    session_start();
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
        <h2>Step 1: Entrance Tickets</h2>
    </div>
    <br />
    <table class="table">
      <tbody>
        <tr>
          <td style="text-align:center;">Regular ticket</td>
          <td style="text-align:center;">€ 55.00 EUR</td>
          <td style="text-align:center;">
            <div class="form-group col-md-4">
                  <select id="inputState" class="form-control">
                    <option >Quantity</option>
                    <option selected>1</option>
                    <option>2</option>
                    <option>3</option>
                  </select>
            </div>
          </td>
        </tr>
        <tr>
          <td style="text-align:center;">Camping spots</td>
          <td style="text-align:center;">€ 30.00 EUR</td>
          <td style="text-align:center;">
            <div class="form-group col-md-4">
                  <select id="inputState" class="form-control">
                    <option >Quantity</option>
                    <option selected>1</option>
                    <option>2</option>
                    <option>3</option>
                  </select>
            </div>
          </td>
        </tr>
        <tr>
          <td></td>
          <td></td>
          <td>Incl 21% btw € 17.00 EUR</td>
        </tr>
        <tr>
          <td></td>
          <td></td>
          <td>Total: € 85.00 EUR</td>
        </tr>
      </tbody>
    </table>
  </div>
    <div class="next">
        <a type="btn" href="tickets2.php" class="btn-next">Next</a>
    </div>
</div>


<?php
include("template/footer.php")
?>
</body>
