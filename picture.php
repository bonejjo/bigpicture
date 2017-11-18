<script language="javascript">
  //php 페이지 자동 새로고침
  window.setTimeout('window.location.reload()',1000); //1초마다 리플리쉬 시킨다 1000이 1초가 된다.
</script>


<?php
    /*echo "??";
    echo filemtime("C:/Bitnami2/wampstack-5.6.30-2/apache2/htdocs/img/i_dvdvugllc817.jpg");
    echo "test";
    echo filemtime("C:/Bitnami2/wampstack-5.6.30-2/apache2/htdocs/img/i_qcfl3gmrxk4f.jpg");*/
    //파일 경로
    $dir = "C:/Bitnami2/wampstack-5.6.30-2/apache2/htdocs/img/";
    //php mysql 연결
    mysql_connect("localhost","root","yb1234");
    mysql_select_db("bigpicture");

    //한글 깨짐 현상 해결
    mysql_query("set bigpicture utf8;");
    mysql_query("set session character_set_connection=utf8;");
    mysql_query("set session character_set_results=utf8;");
    mysql_query("set session character_set_client=utf8;");
/*
    $files = scandir ($dir);
    $firstFile = $dir . $files[2];// because [0] = "." [1] = ".."
    echo nl2br("file: $firstFile");
    $size = getimagesize($firstFile);
    echo nl2br("width: $size[0], height: $size[1]");

    //이미지 정보 mysql db에 insert
    $result = mysql_query("INSERT INTO bigpicture.mypicture (id, title, width, height, day) VALUES (' ', '$firstFile', '$size[0]', '$size[1]', 'filemtime($firstFile)') ON DUPLICATE KEY UPDATE title=VALUES(title);");
      if (!$result) {
        die('Invalid query: ' . mysql_error());
      }*/
      //setcookie("ind")
    // Open a known directory, and proceed to read its contents

    if (is_dir($dir)) {
      if ($dh = opendir($dir)) {
          while (($file = readdir($dh)) !== false) {
            if($file=="."||$file==".."){
              continue;
            }

            echo("filename: $file");
            $size = getimagesize($dir.$file);
            echo("width: $size[0], height: $size[1]");
            echo("time: ");
            echo filemtime("$dir$file")%10000;

            //이미지 정보 mysql db에 insert
            $result = mysql_query("INSERT INTO bigpicture.mypicture (title, width, height, day, id) VALUES ('$file', '$size[0]', '$size[1]', '" . filemtime("$dir$file")%10000 . "', ' ') ON DUPLICATE KEY UPDATE title=VALUES(title);");
              if (!$result) {
                die('Invalid query: ' . mysql_error());
              }
          }
          closedir($dh);
      }
    }
?>