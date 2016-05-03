<?php

$Username = $_REQUEST["Username"];
$Password = $_REQUEST["Password"];

$hostname = "localhost";
$DBName = "unity";
$user = "root";
$PasswordDB ="root";

//$secretKey = "unityGame";

    try {
        $dbh = new PDO('mysql:host='. $hostname .';dbname='. $DBName, $user, $PasswordDB);
        echo "Database connection is successful  ";
        }
    catch(PDOException $e)
        {
        echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage(), '</pre>';
        }

    if (!$Username || !$Password )
    {
    echo " Not everything is filled in, please try again.";
    }
    else
    {
        $stmt = $dbh->query('SELECT * FROM accounts where username ="'.$Username.'" AND password = "'.$Password.'" ');
        $row_count = $stmt->rowCount();

        if($row_count != 0)
        {

            echo "Login successful!";

        }
        else
        {
            echo "Invalid username or password";
        }
    }