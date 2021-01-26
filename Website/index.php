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
    <title>Home</title>
</head>

<body>

  <?php
  include("template/menu.php")
  ?>

<section class="home-info">
    <!-- portfolio item 01-->
    <div class="port-text">
        <h1>Festival info</h1>
        <p>It is a long established fact that a reader will be distracted by the readable content of a page when
            looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution
            of letters, as opposed to using 'Content here, content here', making it look like readable English. Many
            desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a
            search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have
            evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).</p>
    </div>
    <figure class="port-item">
        <img class="port-image" src="img/port01.jpg" alt="portfolio item">
    </figure>

    <!-- portfolio item 02-->
    <figure class="port-item">
        <img class="port-image" src="img/port02.jpg" alt="portfolio item">
    </figure>
    <div class="port-text">
        <h1>Festival info</h1>
        <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the
            industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and
            scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
            into electronic typesetting, remaining essentially unchanged. </p>
    </div>

    <!-- portfolio item 03-->
    <div class="port-text">
        <h1>Festival info</h1>
        <p>Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical
            Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at
            Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a
            Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the
            undoubtable source.</p>
    </div>
    <figure class="port-item">
        <img class="port-image" src="img/port03.jpg" alt="portfolio item">
    </figure>

</section>

<section class="reviews">
    <h1 class="reviews-head">Reviews</h1>
    <!-- review 01-->
    <div class="reviews-full">
        <div class="row rev" >
          <?php
          $conn = mysqli_connect('studmysql01.fhict.local', 'dbi413156', 'dbi413156', 'dbi413156');
          if($qry = mysqli_query($conn,"SELECT * FROM reviews limit 3"))
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
if (isset($_SESSION['isLog']) && isset($_SESSION['isBuy'])) {
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
          url: "rating.php",
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

</html>
