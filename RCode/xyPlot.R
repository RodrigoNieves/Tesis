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
if(!exists("x")){
  x <- 1:100  
}
if(!exists("y")){
  y <- rnorm(100)  
}
if(!exists("imageName")){
	imageName <- "xyplot"
}
df <- data.frame(x,y)

library(ggplot2)

png(paste0(imageName,".png"),width = PNGwidth, height = PNGheight)
g <- ggplot(data= df, aes(x = x,y = y))
g <- g + geom_line()
g <- g + xlab(PNGxlabel)
g <- g + ylab(PNGylabel)
print(g)
dev.off()
