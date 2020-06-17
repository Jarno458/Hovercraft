const website = location.href;
async function getHovercraft(website) {
	const resp = await fetch(`https://hovercraft.azurewebsites.net/api/tooltips?website=${website}`);

	const data = await resp.json();

	return data;
}

function fillTooltip(array) {
	const baseImageUrl = 'https://i.imgur.com/IDpU5PH.jpg';

	array.forEach((value) => {
		const {locator, tooltip} = value;

		// Initialize
		var Tooltips = $(locator);

		Tooltips.on("mouseenter", function (e) {
			$(this).css('position', 'relative');
			console.log('ENTER');
			$(this).append(`
				<div class='HovercraftTooltip'>
					<p class='OnTop'>
	 					<span class="hovercraft-img-box">
    						<img src="${tooltip.iconUrl || baseImageUrl}" />
						</span>
						<span class="hovercraft-header-box">
							${tooltip.header ? tooltip.header : ''}
						</span>
						<span class="hovercraft-txt-box">
							${tooltip.lines.map(x => '<span>' + x + '</span>').join('')}
						</span>
	 				</p>
	 			</div>`)
		});
		Tooltips.on("mouseleave", function (e) {
			console.log('LEAVE');
			$(this).find('.HovercraftTooltip').remove();
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