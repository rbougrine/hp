<?php
include "Login.php";
include 'UserPosition.php';
include 'GameInfo.php';

$Job = $_POST["Job"];

        switch($Job)
        {
            case"LoginAccount":
                $Username = $_POST["Username"];
                $Password = $_POST["Password"];
                $Login = new Login();
                $Login->LoginAccount($Username,$Password);
                break;
            case"RegisterAccount":
                $Username = "test33";
                $Password = '3';
                $Login = new Login();
                $Login->RegisterAccount($Username,$Password);
                break;
            case"CheckPosition":
                $Username = $_POST["Username"];
                $Login = new UserPosition();
                $Login->CheckPosition($Username);
                break;
            case"RetrievePosition":
                $Username = $_POST["Username"];
                $sceneName = $_POST["sceneName"];
                $Login = new UserPosition();
                $Login->RetrievePosition($Username,$sceneName);
                break;
            case"SavePosition":
                $Username = $_POST["Username"];
                $sceneName = $_POST["sceneName"];
                $x = $_POST["x"];
                $y = $_POST["y"];
                $z = $_POST["z"];
                $Login = new UserPosition();
                $Login->SavePosition($x,$y,$z,$sceneName,$Username);
                break;
            case"GetInfo":
                $Username = $_POST["Username"];
                $Login = new GameInfo();
                $Login->GetInfo($Username);
                break;
            case"SaveScore":
                $Username = $_POST["Username"];
                $score = $_POST["score"];
                $Login = new GameInfo();
                $Login->SaveScore($Username,$score);
                break;
            case"SaveTime":
                $Username = $_POST["Username"];
                $Begintime = $_POST["Begintime"];
                $Endtime = $_POST["Endtime"];
                $Login = new GameInfo();
                $Login->SaveTime($Username,$Begintime,$Endtime);
                break;


        }


?>
