var custTemplate = "<div id='labeler'>  \
        <%-Id%>. \
        <%-Title%>.\
        <%-FirstName%>\
        <%-LastName%>\
        </div> \
		<div class='hide' id='editor'>\
		<%-Id%>    \
		<input type='text' id='TitleEdit' placeholder='Title' size='2' maxlength='3' value='<%-Title%>'/> \
		<input type='text' id='FirstNameEdit' placeholder='FirstName' value='<%-FirstName%>'/> \
		<input type='text' id='LastNameEdit' placeholder='LastName' value='<%-LastName%>'/> \
		<input type='button' class='btn btn-info' id='Delete' value='Delete'/> \
		</div>";