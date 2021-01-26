<?php
?>
<header class="v-header contain">
  <div class="header-content">
    <nav class="navbar navbar-expand-sm ">
      <ul class="navbar-nav">
        <li class="nav-item">
            <a class="nav-link" href="index.php">Home</a>
        </li>
        <?php
        if (isset($_SESSION['isLog'])) {
            echo '<li class="nav-item">
            <a class="nav-link" href="tickets1.php">Tickets</a>
        </li>';
        } else {
            echo '<li class="nav-item">
            <a class="nav-link" href="signUp.php">Tickets</a>
        </li>';
        }
        ?>
        <li class="nav-item">
            <a class="nav-link" href="reviews.php">Reviews</a>
        </li>
        <?php
        if (isset($_SESSION['isLog'])) {
            if (isset($_SESSION['user'])) {
                echo '<li class="nav-item">
                    <a class="nav-link" href="userAccount.php">'.$_SESSION['firstName'].'</a>
                   </li>';
            } else {
                echo '<li class="nav-item">
                    <a class="nav-link" href="adminAccount.php">'.$_SESSION['firstName'].'</a>
                   </li>';
            }

            echo '<li class="nav-item">
                    <a class="nav-link" href="logOut.php">LogOut</a>
                   </li>';
        } else {
            echo '<li class="nav-item">
                    <a class="nav-link" href="signUp.php">SignUp</a>
                   </li>';
            echo '<li class="nav-item">
                    <a class="nav-link" href="logIn.php">LogIn</a>
                  </li>';
        }
        ?>
      </ul>
    </nav>
    <div class="logo">
        <a href="index.php"><img src="img/mflogo.png" alt="mf logo"></a>
    </div>
    <h1 class="title">WE OWN THE NIGHT</h1>
    <div class="sub-title">Kuierpad Winter Fest | Wezuperbrug</div>
    <div class="sub-title">24-26 January 2020</div>
          <?php
          if (isset($_SESSION['isLog'])) {
                      echo '<a type="btn" href="tickets1.php" class="btn-tickets">Buy Tickets</a>';
                  } else {
                      echo '<a type="btn" href="signUp.php" class="btn-tickets">Buy Tickets</a>';
                  }
          ?>
    </div>
    <div class="full-screen-video-wrap">
      <video autoplay="autoplay" class="video" muted loop>
          <source src="img/VIDEO-HOMEPAGE_1.mp4" type="video/mp4">
      </video>
    <div/>
  </div>
</header>
