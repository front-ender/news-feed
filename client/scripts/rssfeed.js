$(document).ready(function (){
$('.btnsubmit input').click(function(){	
	$('#newsfeed').each(function(){
		var $container = $(this);
		$container.empty();
		
		var feedUrl = $('#urlfeed').val();
		
		$.get(feedUrl, function(data) {
		    var $xml = $(data);
				var $headline = $('<h4>Headline here..</h4>').append($xml);
				$('<div></div>')
					.append($headline)
					.appendTo($container);
			});
		});	
	});	
});


