import {Pipe, PipeTransform} from "@angular/core";
import {isBlank} from "@angular/core/src/facade/lang";

@Pipe({
  name:"itemSort" ,
  pure:false
})

export class SongItemSortPipe implements PipeTransform{
    transform(input:any, args: any): any{
        return input.sort((a, b) => {
            if (a.title > b.title ) {
                return 1;
            }
            if (a.title < b.title) {
                return -1;
            }
            return 0;
            });      

    }

 

}