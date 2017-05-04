<script language="javascript">
  //php 페이지 자동 새로고침
  window.setTimeout('window.location.reload()',1000); //1초마다 리플리쉬 시킨다 1000이 1초가 된다.
</script>

<?php
    //파일 경로
    $dir = "C:/Bitnami2/wampstack-5.6.30-2/apache2/htdocs/img/";
    //php mysql 연결
    mysql_connect("localhost","root","password");
    mysql_select_db("bigpicture");

    //한글 깨짐 현상 해결
    mysql_query("set bigpicture utf8;");
    mysql_query("set session character_set_connection=utf8;");
    mysql_query("set session character_set_results=utf8;");
    mysql_query("set session character_set_client=utf8;");

    // Open a known directory, and proceed to read its contents
    if (is_dir($dir)) {
      if ($dh = opendir($dir)) {
          while (($file = readdir($dh)) !== false) {
            //파일 안에 이미지부터 받아오게끔 예외처리
              if($file == "."||$file == "..") {
    			      //echo "skip";
            	  continue;
        	  }
              echo nl2br("filename: $file");
              $size = getimagesize($dir.$file);
              echo nl2br("width: $size[0], height: $size[1]");

              //이미지 정보 mysql db에 insert
              $result = mysql_query("INSERT INTO bigpicture.picture (id, pic_name, width, height) VALUES (' ', '$file', '$size[0]', '$size[1]') ON DUPLICATE KEY UPDATE pic_name=VALUES(pic_name);");
              if (!$result) {
                die('Invalid query: ' . mysql_error());
              }
          }
          closedir($dh);
      }
    }
?>
