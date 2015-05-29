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

png(paste0(imageName,".png"),width = PNGwidth, height = PNGheight)
plot(x,y,type= "l", xlab = PNGxlabel, ylab = PNGylabel)
dev.off()
