![image](https://github.com/user-attachments/assets/40d49dc6-cab1-4610-ab67-b76ed9f4fe79)

# Payroll Calculation - Docker Kurulum Talimatları

Bu proje, Docker kullanarak kolayca kurulup çalıştırılabilir. Aşağıdaki adımları takip ederek uygulamayı başlatabilirsiniz.

## Gereksinimler
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) yüklenmiş olmalıdır.
- Docker Compose kurulmuş olmalıdır (Docker Desktop ile birlikte gelir).

## Kurulum ve Çalıştırma
1. **Repoyu Klonlayın:**
   - GitHub reposunu yerel makinenize klonlayın:
     ```bash
     git clone https://github.com/huseyinTalo/payroll-calculation.git
     cd payroll-calculation
     ```

2. **Docker Desktop'u Başlatın:**
   - Docker Desktop uygulamasını açın ve Docker'ın çalıştığından emin olun.

3. **Proje Klasörüne Geçin:**
   - Terminal veya komut satırını açın ve proje klasörüne gidin (eğer klonlama adımını atladıysanız):
     ```bash
     cd /path/to/your/project
     ```

4. **Uygulamayı Çalıştırın:**
   - Aşağıdaki komutu terminalde çalıştırarak uygulamayı başlatın:
     ```bash
     docker-compose run -it --rm payroll-calculation
     ```

Bu komut, Docker konteynerini oluşturup çalıştıracak ve sonrasında konteyneri temizleyecektir.

## Sorun Giderme
- Docker servisinin aktif olduğundan emin olun.
- Komutları doğru klasörde çalıştırdığınızdan emin olun.
- Herhangi bir hata alırsanız, hata mesajını inceleyip eksik bağımlılıkları kontrol edin.

## İletişim
Herhangi bir sorun veya öneriniz için lütfen bizimle iletişime geçin.

---

Keyifli kodlamalar! 🚀

