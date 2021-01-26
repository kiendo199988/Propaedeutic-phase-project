<?php
$mysqli = new mysqli('studmysql01.fhict.local', 'dbi413156', 'dbi413156', 'dbi413156') or die("Connect failed: %s\n" . $conn->error);
$result = $mysqli->query("SELECT COUNT(*) FROM account where role = 0 ");
$row = $result->fetch_assoc();
$result2 = $mysqli->query("SELECT COUNT(*) FROM account where checked_event = 1 ");
$row2 = $result2->fetch_assoc();
$dataPoints1 = array(
  array("y" => $row["COUNT(*)"], "label" => "Total visitors" ),
  array("y" => $row2["COUNT(*)"], "label" => "Visitors checkedIn" ),
  array("y" => $row["COUNT(*)"]- $row2["COUNT(*)"] , "label" => "visitors still out" )
);
$result3 = $mysqli->query("SELECT total FROM ticket ");
$row3 = $result3->fetch_assoc();
$result4 = $mysqli->query("SELECT COUNT(*) FROM account where role = 0 ");
$row4 = $result4->fetch_assoc();
$dataPoints2 = array(
  array("y" => $row3["total"], "label" => "Total Tickets" ),
  array("y" => $row4["COUNT(*)"], "label" => "Sold tickets" ),
  array("y" => $row3["total"]-$row4["COUNT(*)"] , "label" => "Available tickets" )
);
$result5 = $mysqli->query("SELECT total_deposit FROM balance");
$row5 = $result5->fetch_assoc();
$result6 = $mysqli->query("SELECT SUM(balance) FROM account where role = 0 ");
$row6 = $result6->fetch_assoc();
$dataPoints3 = array(
  array("y" => $row5["total_deposit"], "label" => "Total deposit" ),
  array("y" => $row5["total_deposit"]-$row6["SUM(balance)"] , "label" => "Total spent" ),
  array("y" => $row6["SUM(balance)"], "label" => "Total balance" )
);
$result7 = $mysqli->query("SELECT COUNT(*) FROM account where has_cs = 1 ");
$row7 = $result7->fetch_assoc();
$result8 = $mysqli->query("SELECT COUNT(*) FROM account where checked_cs = 1 ");
$row8 = $result8->fetch_assoc();
$dataPoints4 = array(
  array("y" => $row7["COUNT(*)"], "label" => "Has camping spot" ),
  array("y" => $row8["COUNT(*)"], "label" => "Checked In" ),
  array("y" => $row7["COUNT(*)"]-$row8["COUNT(*)"], "label" => "Checked out" )
);
$result13 = $mysqli->query("SELECT total_cs FROM cs ");
$row13 = $result13->fetch_assoc();
$result14 = $mysqli->query("SELECT COUNT(*) FROM account where role = 0 and has_cs=1");
$row14 = $result14->fetch_assoc();
$dataPoints7 = array(
  array("y" => $row13["total_cs"], "label" => "Total camping spots" ),
  array("y" => $row14["COUNT(*)"], "label" => "Reserved camping spots" ),
  array("y" => $row13["total_cs"]-$row14["COUNT(*)"] , "label" => "Available camping spots" )
);
$result9 = $mysqli->query("SELECT COUNT(*) FROM loan ");
$row9 = $result9->fetch_assoc();
$result10 = $mysqli->query("SELECT COUNT(*) FROM loan where borrower IS NOT NULL ");
$row10 = $result10->fetch_assoc();
$dataPoints5 = array(
  array("y" => $row9["COUNT(*)"], "label" => "Total Items" ),
  array("y" => $row10["COUNT(*)"], "label" => "Loaned Items" ),
  array("y" => $row9["COUNT(*)"]-$row10["COUNT(*)"], "label" => "Items in stock" )
);
$result11 = $mysqli->query("SELECT sum(quantity) FROM food ");
$row11 = $result11->fetch_assoc();
$result12 = $mysqli->query("SELECT sum(sold_items) FROM food where sold_items IS NOT NULL");
$row12 = $result12->fetch_assoc();
$dataPoints6 = array(
  array("y" => $row11["sum(quantity)"], "label" => "Total Items" ),
  array("y" => $row12["sum(sold_items)"], "label" => "Sold Items" ),
  array("y" => $row11["sum(quantity)"]-$row12["sum(sold_items)"], "label" => "Items in stock" )
);
$result15 = $mysqli->query("SELECT sum(profit) FROM food ");
$row15 = $result15->fetch_assoc();
$result16 = $mysqli->query("SELECT sum(price) FROM loan where borrower IS NOT NULL");
$row16 = $result16->fetch_assoc();
$dataPoints8 = array(
  array("y" => $row15["sum(profit)"], "label" => "Total profit food shops" ),
  array("y" => $row16["sum(price)"], "label" => "Total profit loan shops" ),
  array("y" => $row15["sum(profit)"]+$row16["sum(price)"], "label" => "Total profit" )
);

$dataPoints9 = array();
$sql = "SELECT name , sold_items from food";
$res = mysqli_query($mysqli, $sql) or die("bad query: $sql");
while ($row17 = mysqli_fetch_assoc($res))
  {
    array_push($dataPoints9, array("y"=> $row17["sold_items"], "label"=> $row17["name"]));
  }

?>
<script>
    window.onload = function () {

    var chart1 = new CanvasJS.Chart("chartContainer1", {
      animationEnabled: true,
      theme: "light1", // "light1", "light2", "dark1", "dark2"
      title:{
              text: "Visitors"
            },
            axisY: {
              title: "Nr of Visitors"
            },
      data: [{
            type: "column",
            yValueFormatString: "### Person",
            dataPoints: <?php echo json_encode($dataPoints1, JSON_NUMERIC_CHECK); ?>
      }]
    });
    var chart2 = new CanvasJS.Chart("chartContainer2", {
      animationEnabled: true,
      theme: "light1", // "light1", "light2", "dark1", "dark2"
      title:{
              text: "Tickets"
            },
            axisY: {
              title: "Nr of Tickets"
            },
      data: [{
            type: "column",
            yValueFormatString: "### Tickets",
            dataPoints: <?php echo json_encode($dataPoints2, JSON_NUMERIC_CHECK); ?>
      }]
    });
    var chart3 = new CanvasJS.Chart("chartContainer3", {
      animationEnabled: true,
      theme: "light1", // "light1", "light2", "dark1", "dark2"
      title:{
              text: "Visitors balance"
            },
            axisY: {
              title: "Euros"
            },
      data: [{
            type: "column",
            yValueFormatString: "### Euros",
            dataPoints: <?php echo json_encode($dataPoints3, JSON_NUMERIC_CHECK); ?>
      }]
    });
    var chart4 = new CanvasJS.Chart("chartContainer4", {
      animationEnabled: true,
      theme: "light1", // "light1", "light2", "dark1", "dark2"
      title:{
              text: "Camping spots IN/Out"
            },
            axisY: {
              title: "Nr of Visitors"
            },
      data: [{
            type: "column",
            yValueFormatString: "### Person",
            dataPoints: <?php echo json_encode($dataPoints4, JSON_NUMERIC_CHECK); ?>
      }]
    });
    var chart5 = new CanvasJS.Chart("chartContainer5", {
      animationEnabled: true,
      theme: "light1", // "light1", "light2", "dark1", "dark2"
      title:{
              text: "Loan Shops Statistics"
            },
            axisY: {
              title: "Nr of Items"
            },
      data: [{
            type: "column",
            yValueFormatString: "### Items",
            dataPoints: <?php echo json_encode($dataPoints5, JSON_NUMERIC_CHECK); ?>
      }]
    });
    var chart6 = new CanvasJS.Chart("chartContainer6", {
      animationEnabled: true,
      theme: "light1", // "light1", "light2", "dark1", "dark2"
      title:{
              text: "Food Shops Statistics"
            },
            axisY: {
              title: "Nr of Items"
            },
      data: [{
            type: "column",
            yValueFormatString: "### Items",
            dataPoints: <?php echo json_encode($dataPoints6, JSON_NUMERIC_CHECK); ?>
      }]
    });
    var chart7 = new CanvasJS.Chart("chartContainer7", {
      animationEnabled: true,
      theme: "light1", // "light1", "light2", "dark1", "dark2"
      title:{
              text: "Camping spots Statistics"
            },
            axisY: {
              title: "Nr of spots"
            },
      data: [{
            type: "column",
            yValueFormatString: "### spots",
            dataPoints: <?php echo json_encode($dataPoints7, JSON_NUMERIC_CHECK); ?>
      }]
    });
    var chart8 = new CanvasJS.Chart("chartContainer8", {
      animationEnabled: true,
      theme: "light1", // "light1", "light2", "dark1", "dark2"
      title:{
              text: "Food/Loan shops profit"
            },
            axisY: {
              title: "Profit"
            },
      data: [{
            type: "column",
            yValueFormatString: "### Euros",
            dataPoints: <?php echo json_encode($dataPoints8, JSON_NUMERIC_CHECK); ?>
      }]
    });
    var chart9 = new CanvasJS.Chart("chartContainer9", {
      animationEnabled: true,
      theme: "light1", // "light1", "light2", "dark1", "dark2"
      title:{
              text: "sold amount per item"
            },
            axisY: {
              title: "items"
            },
      data: [{
            type: "column",
            yValueFormatString: "### items",
            dataPoints: <?php echo json_encode($dataPoints9, JSON_NUMERIC_CHECK); ?>
      }]
    });

    chart1.render();
    chart2.render();
    chart3.render();
    chart4.render();
    chart5.render();
    chart6.render();
    chart7.render();
    chart8.render();
    chart9.render();
    }
    </script>
