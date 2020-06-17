/* $('td:contains("Mark")').hover(
	function() {
		$( this ).tooltip( "option", "content", "Awesome title!" );
		// $( this ).append( $( "<span> ***</span>" ) );
	}, function() {
		$( this ).find( "span" ).last().remove();
	}
); */

/*$('body').append(`<div class="tooltip_templates">
    <span id="tooltip_content">
    	<div class="hovercraft-img-box">
    		<img src="https://w7.pngwing.com/pngs/74/308/png-transparent-book-free-content-stack-s-reading-computer-vertebrate.png" />
		</div>
		<strong>This is the content of my tooltip!</strong>
  	</span>
</div>`)

$('td:contains("Mark")').attr("data-tooltip-content", "#tooltip_content");

$(document).ready(function() {
	$('[data-tooltip-content]').tooltipster({
		trigger: 'click',
		trackOrigin: true
	});
});
*/

// Initialize
var Tooltips = $('td:contains("Larry")');

Tooltips.on("mouseenter", function (e) {
	$(this).css('position', 'relative');
	console.log('ENTER');
	$(this).append(`
	<div class='Tooltips'>
		<p class='OnTop'>
	 		<span class="hovercraft-img-box">
    			<img src="https://i.imgur.com/IDpU5PH.jpg" />
			</span>
			<span class="hovercraft-txt-box">
				<strong>This is the content of my tooltip!</strong>
			</span>
	 	</p>
	 </div>`)
});

Tooltips.on("mouseleave", function (e) {
	console.log('LEAVE');
	$(this).find('.Tooltips').remove();
});

/*	// Event Handler
	Tooltips[i].addEventListener("mouseenter", function(ev) {
		ev.preventDefault();
		this.style.position = "relative";
		this.innerHTML = this.innerHTML + "<div class='Tooltips'><p class='" + this.getAttribute("data-position") + "'>" + this.getAttribute("data-tooltips") + "</p></div>";
	});
	Tooltips[i].addEventListener("mouseleave", function(ev) {
		ev.preventDefault();
		this.removeAttribute("style");
		this.innerHTML = this.innerHTML.replace(/<div[^]*?<\/div>/, '');
	}); */