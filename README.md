## Zigzag-Clone-GAme
Bu çalışma **Unity** ile **Zigzag** oyununun bir kopyasını oluşturmak için yaptığım çalışmadır.

## Mekanikler
  * Top hareketi
    * Oyunucunun touch veya mouse click işlemleri topa yön verebilir.
    * Sağa giden topu sola,
    * Sola giden topu sağa yönde hareket ettirebiliriz.
  * Zemin Hareketleri
    * OnCollisionExit metodu ile top'a verdiğimiz "top" tagı sayesinde zeminlerden çıkan toptan 0.75f sonra zeminlerin düşme efektini gerçekleştiriyoruz.
    * Düşen zemin objeleri en son zemin objesinin arkasına ekleniyor.
    * Zemin objelerin eklenme şekli random bir şekilde sol ya da sağına ekleniyor.
  * Oyuna tekrar başlamak için topumuzun zeminden y ekseninde 10 birim aşağıya düşmesi gerekiyor.

## Gameplay
Game Scene |
------------ | 
![](VideosAndPhotos/zigzagKlip.gif) |