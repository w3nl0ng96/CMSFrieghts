<?php
    try
	{
		$connection = new PDO("sqlsrv:Server=cmsfrieghts2018ddacdbserver.database.windows.net;Database=CMSFrieghts2018DDAC_db", "w3nl0ng96", "Ravemaster96");
		$connection->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
		$connection->setAttribute(PDO::SQLSRV_ATTR_ENCODING, PDO::SQLSRV_ENCODING_SYSTEM);
	}catch (Exception $e)
	{
		echo $e->getMessage();
		die('Fail to connect<br />');
	}    

    try
	{
		$sql = "UPDATE CustomerShipping SET status = 'Pending Receive' WHERE status = 'Delivering';";
		$query = $connection->prepare($sql);
		$query->execute();
		$result = $query->fetchAll(PDO::FETCH_ASSOC);
	}catch (Exception $e)
	{
		die('Fail to fetch rows.');
	}


?>