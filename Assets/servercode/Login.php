<?php


class Login
{
    
       function LoginAccount($Username,$Password)
       {
        require "database.php";
        
        if (!$Username || !$Password )
        {
            echo "Niet alles is in ingevuld";

        }
        else
        {

            $stmt = R::getAll('SELECT * FROM accounts WHERE username = :username',
                array(':username' => $Username) );

            if (!$stmt)
            {
                echo "Username is niet correct";
            }
            else
            {
                foreach ($stmt as $entry)
                $value = $entry['password'];
                $password = decrypt($value, $key);

                if ($Password == $password)
                {
                    echo "Login successful!";
                }
                else
                {
                    echo "Wachtwoord niet correct";
                }
            }

        }
    }//end function

    function RegisterAccount($Username,$Password)
    {
        require "database.php";
        
        if (!$Username || !$Password ) {
            echo "Niet alles is in ingevuld";
        }
        else
        {
            $stmt = R::findAll('accounts', ' username = ? ',array($Username));

            if (!$stmt)
            {
                $password = encrypt($Password,$key);

                R::exec('insert into `accounts` (username,password) values (:username,:password)',
                    array(':username' => $Username, ':password' => $password));

                echo "Registratie successful";
            }
            else
            {
                echo "Username is al in gebruik";
            }
        }

    }//End function

}//end class
?>