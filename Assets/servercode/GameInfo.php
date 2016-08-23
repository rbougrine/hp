<?php
class GameInfo
{
    function GetInfo($Username)
    {
        require 'database.php';

        $entries = R::getAll('SELECT accounts.username , game.level, game.exercise, game.score  FROM accounts ,game
WHERE accounts.username = game.username AND accounts.username = :username',
            array(':username' => $Username) );

        if (!$entries)
        {
            echo 'Username not found';
        }
        else
        {
            foreach ($entries as $entry)

            echo "Naam: " . $entry["username"] . "  Niveau: " . $entry["level"] . " Oefening:" . $entry["exercise"] .
                 " Score:" . "," . $entry["score"];

        }
    }//End function

        function SaveScore($Username,$score)
        {
            require 'database.php';

            $stmt = R::getAll('SELECT * FROM game WHERE username = :username',
                array(':username' => $Username) );

            if (!$stmt)
            {
                echo "Username is niet correct";
            }
            else
            {
                 R::exec( 'UPDATE game SET score = :score WHERE username = :username',
                    array(':score' => $score, ':username' => $Username) );
            }


            
        }//End function

        function SaveTime($Username,$Begintime,$Endtime)
        {
            require 'database.php';

            $stmt = R::getAll('SELECT * FROM game WHERE username = :username',
                array(':username' => $Username) );

            if (!$stmt)
            {
                echo "Username is niet correct";
            }
            else
            {
                R::exec( 'UPDATE game SET begintime = :begintime, endtime = :endtime WHERE username = :username',
                    array(':begintime' => $Begintime, ':endtime' => $Endtime, ':username' => $Username) );



            }
            
            
        }//End function



}//End class

    
    
    
    
    
    
    
    











?>