if(!exists("PNGwidth")){
  PNGwidth <- 480
}
if(!exists("PNGheight")){
  PNGheight <- 480
}
if(!exists("PNGxlabel")){
  PNGxlabel <- ""
}
if(!exists("PNGylabel")){
  PNGylabel <- ""
}
if(!exists("x1")){
  x1 <- 1:100  
}
if(!exists("y1")){
  y1 <- rnorm(100)  
}

if(!exists("x2")){
  x2 <- 1:30  
}
if(!exists("y2")){
  y2 <- rnorm(30)  
}

if(!exists("imageName")){
	imageName <- "xyplot"
}

if(!exists("name1")){
  name1 <- "Simulación 1"
}

if(!exists("name2")){
  name2 <- "Simulación 2"
}

library(ggplot2)


df1 <- data.frame(x = x1,y1)
df2 <- data.frame(x = x2,y2)
df <- merge(df1,df2, by = "x", all = TRUE)


png(paste0(imageName,".png"),width = PNGwidth, height = PNGheight)
g <- ggplot(data= df, aes(x))
g <- g + geom_line(aes(y = y1, colour = name1))
g <- g + geom_line(aes(y = y2, colour = name2))
g <- g + xlab(PNGxlabel)
g <- g + ylab(PNGylabel)
if(exists("y_scale"))
{
  g <- g + y_scale
}
print(g)
dev.off()

