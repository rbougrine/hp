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
} catch(PDOException $e) {

    echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage(), '</pre>';
}

    if (!$Username || !$Password ) {
        echo "One or more field are still empty";
    }
    else
    {
        $stmt = $dbh->query('SELECT * FROM accounts where username ="'.$Username.'"');
        $row_count = $stmt->rowCount();

        if($row_count == 0)
        {
            $stmt = $dbh->prepare("INSERT INTO accounts (username, password) VALUES (:username, :password)");
            $stmt->bindParam(':username', $Username);
            $stmt->bindParam(':password', $Password);
            $stmt->execute();
            echo "New user is added to the database";

        }
        else
        {
            echo "Username is already used, please choose another one.";
        }

    }
