const website = location.href;
async function getHovercraft(website) {
	const resp = await fetch(`https://hovercraft.azurewebsites.net/api/tooltips?website=${website}`);

	const data = await resp.json();

	return data;
}

function fillTooltip(array) {
	const baseImageUrl = 'https://i.imgur.com/IDpU5PH.jpg';

	array.forEach((value, key) => {
		const {locator, tooltip} = value;

		// Initialize
		var Tooltips = $(locator);

		Tooltips.on("mouseenter", function (e) {
			$(this).css('position', 'relative');
			console.log('ENTER');
			$(this).append(`
				<div class='Tooltips'>
					<p class='OnTop'>
	 					<span class="hovercraft-img-box">
    						<img src="${tooltip.iconUrl || baseImageUrl}" />
						</span>
						<span class="hovercraft-txt-box">
							<strong>${tooltip.header}</strong>
							${tooltip.lines.map(x => '<span>' + x + '</span>').join('')}
						</span>
	 				</p>
	 			</div>`)
		});
		Tooltips.on("mouseleave", function (e) {
			console.log('LEAVE');
			$(this).find('.Tooltips').remove();
		});
	});
}

getHovercraft(website).then(
	result => {
		// первая функция-обработчик - запустится при вызове resolve
		fillTooltip(result);
	},
	error => {
		// вторая функция - запустится при вызове reject
		console.error("Rejected: " + error); // error - аргумент reject
	}
);