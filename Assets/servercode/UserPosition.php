<?php
class UserPosition
{

    function CheckPosition($Username)
    {
        require "database.php";

        $sceneName = "Game";

        $stmt = R::getAll('SELECT * FROM game WHERE username = :username',
            array(':username' => $Username) );

        if (!$stmt)
        {
            echo "Username is niet correct";
        }
        else
        {
            foreach ($stmt as $entry)

            if($entry["x"] == 0)
            {
                echo "empty";
            }
            elseif ($entry["scene"] == $sceneName)
            {
                echo $entry["x"].",".$entry["y"].",".$entry["z"].",".$sceneName;
            }
            else
            {
                echo $entry["x"].",".$entry["y"].",".$entry["z"].",".$entry["scene"];
            }


        }


    }//end function

    function RetrievePosition($Username,$sceneName)
    {
        require 'database.php';

        $entries = R::getAll('SELECT * FROM game WHERE username = :username',
            array(':username' => $Username) );
       
        if (!$entries)
        {
            echo 'Username not found';
        }
        else
        {
            foreach ($entries as $entry)

            if($entry["x"] == 0)
            {
                echo "change";
            }
            elseif ($entry["scene"] == $sceneName)
            {
                echo "change";
            }
            else
            {
                echo $entry["x"].",".$entry["y"].",".$entry["z"];
            }
        }

    }//end function

    function SavePosition($x,$y,$z,$sceneName,$Username)
    {
        require 'database.php';

        $stmt = R::getAll('SELECT * FROM game WHERE username = :username',
            array(':username' => $Username) );

        if(!$stmt)
        {
            echo'Username is niet correct';

        }
        else
        {
            R::exec( 'UPDATE game SET x = :x , y = :y , z = :z, scene = :scene WHERE username = :username',
            array(':x' => $x,':y' => $y,':z' => $z,':scene' => $sceneName, ':username' => $Username) );
        }

    }//End function
        

    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}































?>