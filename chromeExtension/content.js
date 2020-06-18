const website = location.href;
async function getHovercraft(website) {
	const resp = await fetch(`https://hovercraft.azurewebsites.net/api/tooltips?website=${website}`);

	return await resp.json();
}

function fillTooltip(array) {
	const baseImageUrl = 'https://i.imgur.com/IDpU5PH.jpg';

	array.forEach((value) => {
		const {locator, backgroundColor, textColor, tooltip} = value;

		$('body').on("mouseenter", locator,function (e) {
			$(this).css('position', 'relative');

			const position = $(this).offset();
			position.top += $(this).height() + 20;

			// if element is on the right side
			if (position.left > 0.85 * window.screen.width) {
				position.left = position.left - $(this).width();
			}

			$('body').append(`
				<div class='HovercraftTooltip'>
					<div class='table-row' style='background:${backgroundColor}'>
						<div class='table-cell' style='color:${textColor};background:${backgroundColor}'>
							<span class="hovercraft-img-box">
								<img src="${tooltip.iconUrl || baseImageUrl}" />
							</span>
						</div>
						<div class='table-cell' style='color:${textColor};background:${backgroundColor}'>
							<span class="hovercraft-header-box">
								${tooltip.header ? tooltip.header : ''}
							</span>
							<span class="hovercraft-txt-box">
								${tooltip.lines.map(x => '<span>' + x + '</span>').join('<br/>')}
							</span>
						</div>
					</div> 
	 			</div>`).find('.HovercraftTooltip').css({...position, position:'absolute'})
		});
		$('body').on("mouseleave", locator,function (e) {
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