$(document).ready(function (){
$('.btnsubmit input').click(function(){	
	$('#newsfeedresult').each(function(){
		var $container = $(this);
		$container.empty();
		
		var feedUrl = $('#urlProxy').val();
		feedUrl+= '?uri=';
		feedUrl+= $('#queryStringUrl').val();
		
		
		$.get(feedUrl, function(data) {
		    var $xml = $(data);
		    var count=0;
		    
		    try{
			    var $items = $xml.find('item');
			    
			    $items.each(function(){
			       	try
			       	{
			       		count++;
			       		if(count>10)
			       		{
			       			return;
			       		}
			       			
				    	var $headline = $('<h4></h4>')
				    	.append(count+')&nbsp;')
				    	.append($('pubdate', this).text())
				    	.append(':')
				    	.append()
				    	.append('<b>'+$('title', this).text()+'</b>');
				    	var $description = $('<p>Story:</p>').append($('description', this).text());
				    	var $textlink = $('<a></a>')
				    		.attr('href', $('guid', this).text())
			    			.text($('title', this).text());
						try{
					    	var $img1 = $('<img></img>')
				    		.attr('src', this.childNodes[11].attributes['url'].value)
				    		.addClass('thumbnail')
			    			.text('');
						}
						catch(exception){
							console.log(exception);
						}
						try{
					    	var $img2 = $('<img></img>')
				    		.attr('src', this.childNodes[13].attributes['url'].value)
				    		.addClass('fullsize')
			    			.text('');
						}
						catch(exception){
							console.log(exception);							
						}


				    	$('<div></div>')
							.append($img1)
							.append('&nbsp;&nbsp;&nbsp;')
							.append($headline)
							.append($description)
							.append($textlink)
							.append($img2)
							.append('<p><br></p>')
							.appendTo($container);
			       	}
			       	catch(exception){
						var $headline = $('<h4>Item empty</h4>').append($xml);
						$('<div>No item here.</div>')
							.append($headline)
							.appendTo($container);			       		
			       	}
				});
		    }
		    catch(exception)
		    {
				var $headline = $('<h4>Headline here..</h4>').append($xml);
				$('<div>No items found in this feed..</div>')
					.append($headline)
					.appendTo($container);
		    }
		    
		});	
	});
});
});



