const website = location.href;
async function getHovercraft(website) {
	const resp = await fetch(`https://hovercraft.azurewebsites.net/api/tooltips?website=${website}`);

	const data = await resp.json();

	// const data = [{"locator":"div .flex-list-container div:contains(\"tst\")","tooltip":{"iconUrl":null,"header":"Varndagroth","lines":["Location: Varndagray Metropolis","HP: 800","Exp: 100","Strong vs: Dark","Weak vs: Fire, Ice, Light"]}},{"locator":"td:contains(\"Aelana\")","tooltip":{"iconUrl":"https://www.neoseeker.com/timespinner/File:Timespinner_aelana_icon.jpg","header":"Aelana","lines":["Location: Royal Towers","HP: 2250","Exp: 300","Strong vs: Lightning ","Weak vs: Aura, Dark"]}}]
	return data;
}

function fillTooltip(array) {
	const baseImageUrl = 'https://i.imgur.com/IDpU5PH.jpg';

	array.forEach((value) => {
		const {locator, tooltip} = value;

		// Initialize
		// var Tooltips = $(locator);

		$('body').on("mouseenter", locator,function (e) {
			$(this).css('position', 'relative');
			console.log('ENTER');
			console.log(`${tooltip.lines.map(x => '<span>' + x + '</span>').join(``)}`);
			const position = $(this).offset();
			position.top += $(this).height() + 20;
			console.log(position);

			$('body').append(`
				<div class='HovercraftTooltip'>
					<p class='OnTop'>
	 					<span class="hovercraft-img-box">
    						<img src="${tooltip.iconUrl || baseImageUrl}" />
						</span>
						<span class="hovercraft-header-box">
							${tooltip.header ? tooltip.header : ''}
						</span>
						<span class="hovercraft-txt-box">
							${tooltip.lines.map(x => '<span>' + x + '</span>').join('<br/>')}
						</span>
	 				</p>
	 			</div>`).find('.HovercraftTooltip').css({...position, position:'absolute'})
		});
		$('body').on("mouseleave", locator,function (e) {
			console.log('LEAVE');
			$('body').find('.HovercraftTooltip').remove();
		});
	});
}

getHovercraft(website).then(
	result => {
		fillTooltip(result);
	},
	error => {
		console.error("Rejected: " + error);
	}
);