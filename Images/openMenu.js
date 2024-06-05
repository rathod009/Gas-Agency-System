// JavaScript Document
function openMenu(row,butno)
{
document.images['one'].src='images/light.gif';
document.images['eleven'].src='images/light.gif';
document.images['Two'].src='images/light.gif';
document.images['four'].src='images/light.gif';

    var tbl  = document.getElementById('main');
    var rows = tbl.getElementsByTagName('tr');
//for (var row=0; row<rows.length;row++) {
//var cels = rows[row].getElementsByTagName('td')
//cels[col_no].style.display=stl;'
for (i=1;i<=7;i=i+2)
{
	if(row==i)
	{
	    if(main.firstChild.childNodes[i].style.display == "block")
	      {
	        main.firstChild.childNodes[i].style.display = "none";
	        document.images[butno].src='images/light.gif';
	      }
	      else
	    {
		  main.firstChild.childNodes[i].style.filter = "revelTrans(duration=2)";
	      main.firstChild.childNodes[i].style.display = "block";
	      document.images[butno].src='images/glight.gif';
	     }
	}
	else
		{
		main.firstChild.childNodes[i].style.display = "none";
		}

}		
	
	 //if(main.firstChild.childNodes[row].style.display == "block")
	 // 	main.firstChild.childNodes[row].style.display = "none";
     //else
	  //  main.firstChild.childNodes[row].style.display = "block";
//rows[row].style.display="block";
//main.firstChild.childNodes[0].
}
