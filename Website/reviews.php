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
    <title>Reviews</title>
</head>

<body>

<div class="header">
  <?php
  include("template/menu_pages.php")
  ?>
    <div class="head-line">
        <h1>Reviews</h1>
    </div>
</div>
<section class="reviews">
    <div class="reviews-full">
      <div class="row rev" >
        <?php
        $conn = mysqli_connect('studmysql01.fhict.local', 'dbi413156', 'dbi413156', 'dbi413156');
        if($qry = mysqli_query($conn,"SELECT * FROM reviews"))
        {
          while($show = mysqli_fetch_assoc($qry))
          {
            echo '<div class="col-md-12">';
            echo '<h2 class="user-review">'.$show['name'].'</h2>';
                  if($show['rating']==1){ echo "<td><i class='fa fa-star'></i></td>"; }
                  if($show['rating']==2){ echo "<td><i class='fa fa-star'></i><i class='fa fa-star'></i></td>"; }
                  if($show['rating']==3){ echo "<td><i class='fa fa-star'></i><i class='fa fa-star'></i><i class='fa fa-star'></i></td>"; }
                  if($show['rating']==4){ echo "<td><i class='fa fa-star'></i><i class='fa fa-star'></i><i class='fa fa-star'></i><i class='fa fa-star'></i></td>"; }
                  if($show['rating']==5){ echo "<td><i class='fa fa-star'></i><i class='fa fa-star'></i><i class='fa fa-star'></i><i class='fa fa-star'></i><i class='fa fa-star'></i></td>"; }
            echo '<p class="review-text">'.$show['text'].'</p>
                  </div>
                  <hr>';
          }
        }
        ?>
      </div>
    </div>
    <div class="show-more">
        <a type="btn" href="reviews.php" class="btn-show-more">Show more</a>
    </div>
</section>
<br><br>
<?php
if (isset($_SESSION['isLog']) && isset($_SESSION['isBuy']))
{
  echo '
      <form class="review-form" action="" method="post">
        <h2 class="rating">Add review</h2>
        <div class=\'starrr\' id=\'rating\'></div> 	<br>
        <div class="revi">
          <input type="text" id="name" name="name" placeholder="Name" required><br>
          <textarea type="text" id="text" name="text" placeholder="Your review" required></textarea>
          <button type="submit" id="submit" name="submit" class="btn-add" required>Add</button>
        </div>
      </form>';
}
?>
<script src="ratingstar.js"></script>
<script>
// rating
var rate;
$('#rating').starrr({
  change: function(e, value){
  	rate = value;
    if (value) {
      $('.your-choice-was').show();
    } else {
      $('.your-choice-was').hide();
    }
  }
});
// ajax submit
$("#submit").click(function(){
	var name = $('#name').val();
	var text = $('#text').val();
	$.ajax({
        url: 'rating.php',
        type: 'post',
        data: {v1 : name, v2 : text, v3 : rate},
        success: function (status) {
        	if(status == 1){
            	$('.msg').html('<b>review Inserted !</b>');
        	}else{
            	$('.msg').html('<b>Server side error !</b>');
        	}
        }
    });

});
</script>
<?php
include("template/footer.php")
?>

</body>
